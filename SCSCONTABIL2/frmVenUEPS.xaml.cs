using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using Xceed.Wpf.Toolkit;

namespace SCSCONTABIL2
{
    /// <summary>
    /// Interaction logic for frmVenUEPS.xaml
    /// </summary>
    public partial class frmVenUEPS : Window
    {
        Conexao conexao = new Conexao();
        int codigoVenda = 0;
        public frmVenUEPS()
        {
            InitializeComponent();
            atualizaDataGrid();
            txtVto.Text = "0,00";
            txtVun.Text = "0,00";
            txtProd.MaxLength = 39;
            txtQtd.MaxLength = 6;
            txtVun.MaxLength = 9;
            txtVto.MaxLength = 15;
        }

        private void btnBus_Click(object sender, RoutedEventArgs e)
        {
            //lista da classe abstrata Produto que receberá os produtos
            var lista = new List<Produto>();
            String busca = txtBusca.Text;
            //buscar os produtos conforme o nome que o usuario digitar
            MySqlCommand buscaProd = new MySqlCommand("select * from produto where ProNom like '%' ?nome '%'", conexao.con);
            buscaProd.Parameters.Add(new MySqlParameter("?nome", busca));
            //limpar o datagrid
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.Items.Refresh();
            //abrir BD
            conexao.abrir();
            //ler as informações do banco de dados
            using (MySqlDataReader leitor = buscaProd.ExecuteReader())
            {
                while (leitor.Read())
                {
                    //classe abstrata para dados de produtos
                    Produto produto = new Produto();
                    //info do BD
                    produto.ProCod = Convert.ToInt32(leitor["ProCod"]);
                    produto.ProNom = leitor["ProNom"].ToString();
                    produto.ProPco = Convert.ToDecimal(leitor["ProPco"]);
                    produto.data = (DateTime)leitor["ProDat"];
                    produto.ProDat = produto.data.ToShortDateString();
                    produto.ProQtd = Convert.ToInt32(leitor["ProQtd"]);
                    //adiciona as variaveis a uma lista
                    lista.Add(produto);
                }
            }
            //adiciona a lista ao dataGrid
            dataGrid.ItemsSource = lista;
            txtBusca.Text = "";
            conexao.fechar();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //instância da classe frmPrincipal
            frmPrincipal frmpri = new frmPrincipal();
            //Fecha esse form e abre o frmPrincipal
            frmpri.Show();
            this.Close();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //variavel de codigo do fornecedor
                int forne = 0;
                //pega a linha selecionada no datagrid
                Produto dados = (Produto)(dataGrid.SelectedItem);
                //pega o codigo do produto
                int codigo = dados.ProCod;
                //informações do produto
                MySqlCommand buscaProd = new MySqlCommand("select ProNom, ProFor from produto where ProCod = ?codigo", conexao.con);
                buscaProd.Parameters.Add(new MySqlParameter("?codigo", codigo));


                //abrir conexao
                conexao.abrir();
                //ler as informações do produto
                using (MySqlDataReader leitor = buscaProd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        txtProd.Text = leitor["ProNom"].ToString();
                        forne = int.Parse(leitor["ProFor"].ToString());
                    }
                    leitor.Close();
                }

                //informações do fornecedor
                MySqlCommand buscaFor = new MySqlCommand("select * from fornecedor where ForCod = ?codigo", conexao.con);
                buscaFor.Parameters.Add(new MySqlParameter("?codigo", forne));

                using (MySqlDataReader leitor = buscaFor.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        txtRazao.Text = leitor["ForRaz"].ToString();
                        txtNome.Text = leitor["ForNom"].ToString();
                        txtImu.Text = leitor["ForImu"].ToString();
                        txtIes.Text = leitor["ForIes"].ToString();
                        txtCnpj.Text = leitor["ForCnp"].ToString();
                    }
                    leitor.Close();
                }
                conexao.fechar();
            }
            catch (Exception erro)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
                conexao.fechar();
            }
        }

        private void atualizaDataGrid()
        {
            try
            {
                //lista que sera adicionada ao datagrid
                var lista = new List<Produto>();

                //limpar o datagrid
                dataGrid.ItemsSource = null;
                dataGrid.Items.Clear();
                dataGrid.Items.Refresh();

                //abre BD
                conexao.abrir();

                MySqlCommand datagrid = new MySqlCommand("select * from produto", conexao.con);
                using (MySqlDataReader leitor = datagrid.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        //classe abstrata para dados de produtos
                        Produto produto = new Produto();
                        produto.ProCod = Convert.ToInt32(leitor["ProCod"]);
                        produto.ProNom = leitor["ProNom"].ToString();
                        produto.data = (DateTime)leitor["ProDat"];
                        produto.ProDat = produto.data.ToShortDateString();
                        produto.ProQtd = Convert.ToInt32(leitor["ProQtd"]);
                        //adiciona as variaveis a uma lista
                        lista.Add(produto);

                    }
                    leitor.Close();

                }
                //adiciona a lista ao datagrid
                dataGrid.ItemsSource = lista;

                conexao.fechar();
            }
            catch (Exception erro)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
                conexao.fechar();
            }
        }

        private void txtQtd_KeyDown(object sender, KeyEventArgs e)
        {
            //bloqueia a digitação de valores diferentes de numeros no textbox
            e.Handled = !recebeNumero(e.Key);

        }


        private bool recebeNumero(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }

        private void Moeda(ref TextBox txt)
        {
            //faz uma mascara para digitar o preco
            String n = "";
            Double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                {
                    n = "";
                }
                n = n.PadLeft(3, '0');
                if ((n.Length > 3) && (n.Substring(0, 1) == "0"))
                {
                    n = n.Substring(1, n.Length - 1);
                }
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception erro)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
                conexao.fechar();
            }
        }

        private void txtQtd_LostFocus(object sender, RoutedEventArgs e)
        {
            String precoUn = txtVun.Text.Replace(".", "").Replace(",", ".");
            if (!txtQtd.Text.Equals("") && !precoUn.Equals("0.00"))
            {

                Decimal precoF = Convert.ToDecimal(precoUn);
                int unidades = Convert.ToInt32(txtQtd.Text);
                txtVto.Text = Convert.ToString(precoF * unidades);
            }
        }

        private void txtVun_TextChanged(object sender, TextChangedEventArgs e)
        {
            Moeda(ref txtVun);
        }

        private void txtVto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Moeda(ref txtVto);
        }

        private void txtVun_KeyDown(object sender, KeyEventArgs e)
        {
            //bloqueia a digitação de valores diferentes de numeros no textbox
            e.Handled = !recebeNumero(e.Key);
        }

        private void txtVun_LostFocus(object sender, RoutedEventArgs e)
        {
            String precoUn = txtVun.Text.Replace(".", "").Replace(",", ".");
            if (!txtQtd.Text.Equals("") && !precoUn.Equals("0.00"))
            {

                Decimal precoF = Convert.ToDecimal(precoUn);
                int unidades = Convert.ToInt32(txtQtd.Text);
                txtVto.Text = Convert.ToString(precoF * unidades);
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtProd.Text.Equals("") || txtQtd.Text.Equals("") || txtVun.Text.Equals("0,00")
                    || txtVto.Text.Equals("0,00") || txtData.semFormato().Equals("")))
                {
                    int qtd = 0;
                    int qtdTela = Convert.ToInt32(txtQtd.Text);
                    MySqlCommand buscaProd = new MySqlCommand("select ProQtd from produto where ProNom = ?nome", conexao.con);
                    buscaProd.Parameters.Add(new MySqlParameter("?nome", txtProd.Text));


                    //abrir conexao
                    conexao.abrir();
                    //ler as informações do produto
                    using (MySqlDataReader leitor = buscaProd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            qtd += Convert.ToInt32(leitor["ProQtd"]);
                        }
                        leitor.Close();
                    }
                    conexao.fechar();
                    if (qtdTela > qtd)
                    {
                        lblStatus.Foreground = Brushes.Red;
                        lblStatus.Content = "Quantidade maior do que a disponivel";

                    }
                    else
                    {
                        verificar_codigo();
                    }
                }
                else
                {
                    lblStatus.Foreground = Brushes.Red;
                    lblStatus.Content = "Preencha todos os campos obrigatórios";
                }
            }
            catch (Exception erro)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
                conexao.fechar();
            }
        }


        private void verificar_codigo()
        {
            try
            {

                Boolean lugar = false;

                while (lugar == false)
                {
                    //Variavel com os comandos de consulta do codigo
                    MySqlCommand consultaCod = new MySqlCommand("select * from vendaUEPS where VenCod = ?codigo", conexao.con);
                    //adiciona parametros ao comando String, evita problemas com SQL Inject
                    consultaCod.Parameters.Add(new MySqlParameter("?codigo", codigoVenda));
                    //abrir conexao com BD
                    conexao.abrir();
                    //É executado e lido o comando.
                    using (MySqlDataReader readerCod = consultaCod.ExecuteReader())
                    {
                        //verificar o primeiro lugar vago para cadastrar usuario
                        //verificar se o codigo ja está em uso
                        if (readerCod.HasRows)
                        {   //se estiver em uso procura pelo proximo
                            codigoVenda++;
                        }
                        else
                        {
                            //fechar reader
                            readerCod.Close();
                            //fechar conexao
                            conexao.fechar();
                            lugar = true;
                            efetuarCompra();
                        }
                    }
                    conexao.fechar();
                }

            }
            catch (Exception erro)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message + "asd";
                conexao.fechar();
            }
        }


        private void efetuarCompra()
        {
            String precoTo = txtVto.Text.Replace(".", "").Replace(",", ".");
            String precoUn = txtVun.Text.Replace(".", "").Replace(",", ".");
            DateTime data = Convert.ToDateTime(txtData.Text);
            int tamanhoLista = 0;
            //lista da classe abstrata Produto que receberá os produtos
            var lista = new List<Produto>();
            try
            {
                MySqlCommand buscaProd = new MySqlCommand("select * from produto where ProNom = ?nome order by date(ProDat) desc", conexao.con);
                buscaProd.Parameters.Add(new MySqlParameter("?nome", txtProd.Text));
                conexao.abrir();
                using (MySqlDataReader leitor = buscaProd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Produto produto = new Produto();
                        produto.ProCod = Convert.ToInt32(leitor["ProCod"]);
                        produto.ProQtd = Convert.ToInt32(leitor["ProQtd"]);
                        //adiciona as variaveis a uma lista
                        lista.Add(produto);
                    }
                    leitor.Close();
                }
                int qtd = Convert.ToInt32(txtQtd.Text);
                tamanhoLista = lista.Count;
                for (int cont = 0; cont < tamanhoLista; cont++)
                {
                    if (qtd > lista[cont].ProQtd)
                    {
                        qtd -= lista[cont].ProQtd;
                        lista[cont].ProQtd = 0;
                    }
                    else
                    {
                        lista[cont].ProQtd -= qtd;
                        qtd = 0;
                    }

                    if (qtd == 0)
                    {
                        cont = tamanhoLista + 1;
                    }
                }

                for (int cont = 0; cont < tamanhoLista; cont++)
                {
                    MySqlCommand atualizaQtd = new MySqlCommand("update produto set ProQtd = ?qtd where ProCod = ?codigo", conexao.con);
                    atualizaQtd.Parameters.Add(new MySqlParameter("?qtd", lista[cont].ProQtd));
                    atualizaQtd.Parameters.Add(new MySqlParameter("?codigo", lista[cont].ProCod));

                    atualizaQtd.ExecuteNonQuery();
                }
                MySqlCommand confirmaVenda = new MySqlCommand("insert into vendaUEPS values (?codigo, ?produto, ?qtd, ?data, ?vuni, ?vtot)", conexao.con);
                confirmaVenda.Parameters.Add(new MySqlParameter("?codigo", codigoVenda));
                confirmaVenda.Parameters.Add(new MySqlParameter("?produto", txtProd.Text));
                confirmaVenda.Parameters.Add(new MySqlParameter("?qtd", txtQtd.Text));
                confirmaVenda.Parameters.Add(new MySqlParameter("?data", data));
                confirmaVenda.Parameters.Add(new MySqlParameter("?vuni", precoUn));
                confirmaVenda.Parameters.Add(new MySqlParameter("?vtot", precoTo));

                confirmaVenda.ExecuteNonQuery();
                conexao.fechar();
                lblStatus.Foreground = Brushes.Green;
                lblStatus.Content = "Venda cadastrada com sucesso";
                atualizaDataGrid();
            }
            catch (Exception erro)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
                conexao.fechar();
            }
        }
    }
}
