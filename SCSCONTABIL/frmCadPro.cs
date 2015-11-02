using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SCSCONTABIL
{
    public partial class frmCadPro : Form
    {
        //instancia da classe conexao
        Conexao conexao = new Conexao();
        //codigo do fornecedor no bd
        static private int fornecedor;
        //codigo que será cadastrado o produto
        static private int cod = 1;
        //preco do produto
        static private String preco;
        public frmCadPro()
        {
            InitializeComponent();
        }

        private void lblStatus_SizeChanged(object sender, EventArgs e)
        {
            //centraliza o label
            lblStatus.Left = (this.ClientSize.Width - lblStatus.Size.Width) / 2;
        }

        
        private void btnVol_Click(object sender, EventArgs e)
        {
            //instância da classe frmPrincipal
            frmPrincipal frmpri = new frmPrincipal();
            //Fecha esse form e abre o frmPrincipal
            frmpri.Show();
            this.Close();
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            //valida o campo do cnpj e manda para pesquisa
            if (txtCnpj.semFormato().Equals(""))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Digite o CNPJ";
            }
            else
            {
                busca_for();
            }
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            //verifica se todos os campos foram preenchidos
            if(txtCnpj.semFormato().Equals("") || txtRazao.Text.Equals("") ||
                txtNome.Text.Equals("") || txtIes.semFormato().Equals("") ||
                txtImu.semFormato().Equals("") || txtNomePro.Text.Equals("") ||
                txtPreco.Text.Equals(""))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preencha todos os campos com *";
            }
            else
            {//dps de validados os dados vai procurar um codigo disponivel para cadastrar
                consultar_codigo();
            }
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            //troca ponto (separador de milhares) por vazio
            //troca a virgula(separador de centavos) por ponto
            preco = txtPreco.Text.Replace(".", "").Replace(",", ".");
        }
        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            //chama o metodo que formatara o valor
            Moeda(ref txtPreco);
        }
        
        private void txtCnpj_Click(object sender, EventArgs e)
        {
            if (txtCnpj.semFormato().Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtCnpj.SelectionStart = 0;
                txtCnpj.ScrollToCaret();
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //bloqueia a digitação de valores diferentes de numeros, backspace, e ponto no textbox
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
            
            //limita somente a 1 ponto (para separar os centavos) no textbox
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //só permite numeros e o backspace no textbox
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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
            catch (Exception e)
            {

            }
        }

        private void busca_for()
        {//pesquisa o fornecedor pelo CNPJ
            try
            {

                //le o comando e adiciona os parametros
                MySqlCommand buscaFor = new MySqlCommand("select * from fornecedor where ForCnp = ?cnpj", conexao.con);
                buscaFor.Parameters.Add(new MySqlParameter("?cnpj", txtCnpj.semFormato()));
                //abre a conexao com o bd
                conexao.abrir();
                using (MySqlDataReader leitor = buscaFor.ExecuteReader())
                {
                    //se a pesquisa retornar dados, eles serão apresentados ao usuario
                    if (leitor.HasRows)
                    {
                        while (leitor.Read())
                        {
                            txtRazao.Text = leitor["ForRaz"].ToString();
                            txtNome.Text = leitor["ForNom"].ToString();
                            txtIes.Text = leitor["ForIes"].ToString();
                            txtImu.Text = leitor["ForImu"].ToString();
                            fornecedor = Convert.ToInt32(leitor["ForCod"]);
                            txtNomePro.Focus();
                            lblStatus.Text = "";
                        }
                        conexao.fechar();
                    }
                    else
                    {
                        //se não for retornado nenhum dado a msg abaixo será exibida
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "CNPJ não encontrado";
                        leitor.Close();
                        conexao.fechar();
                        txtCnpj.Focus();
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("1" + erro.ToString());
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;
                conexao.fechar();
            }
        }

        private void consultar_codigo()
        {
            try
            {
                Boolean lugar = false;

                while (lugar == false)
                {

                    //Variavel com os comandos de consulta do codigo
                    MySqlCommand consultaCod = new MySqlCommand("select * from produto where ProCod = ?codigo", conexao.con);
                    //adiciona parametros ao comando String, evita problemas com SQL Inject
                    consultaCod.Parameters.Add(new MySqlParameter("?codigo", cod));
                    //abrir conexao com BD
                    conexao.abrir();
                    using (MySqlDataReader readerCod = consultaCod.ExecuteReader())
                    {
                        //verificar o primeiro lugar vago para cadastrar fornecedor
                        //verificar se o codigo ja está em uso
                        if (readerCod.HasRows)
                        {   //se estiver em uso procura pelo proximo
                            cod++;
                            conexao.fechar();
                        }
                        else
                        {
                            //fechar reader
                            readerCod.Close();
                            //fechar conexao
                            conexao.fechar();
                            lugar = true;
                            cadastrar();
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("2" + erro.ToString());
                //fechar conexao
                conexao.fechar();
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;
            }
        }

        private void cadastrar()
        {//ira cadastrar o produto

            DateTime data = DateTime.Now;
            try
            {   //abre a conexao com o bd
                conexao.abrir();
                //comando do bd
                MySqlCommand cadastroPro = new MySqlCommand("insert into produto values (?codigo, ?nome, ?fornecedor, ?preco, ?data, ?qtd)", conexao.con);
                cadastroPro.Parameters.Add(new MySqlParameter("?codigo", cod));
                cadastroPro.Parameters.Add(new MySqlParameter("?nome", txtNomePro.Text));
                cadastroPro.Parameters.Add(new MySqlParameter("?fornecedor", fornecedor));
                cadastroPro.Parameters.Add(new MySqlParameter("?preco", preco));
                cadastroPro.Parameters.Add(new MySqlParameter("?data", data));
                cadastroPro.Parameters.Add(new MySqlParameter("?qtd", txtQtd.Text));
                //executa o comando        
                cadastroPro.ExecuteNonQuery();
                conexao.fechar();
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Produto cadastrado com sucesso!";
                limpar();
                txtCnpj.Focus();
            }
            catch (Exception erro)
            {
                //caso de erro no cadastro
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;
                conexao.fechar();
            }
        }
        private void limpar()
        {
            //limpa o form
            txtCnpj.Text = "";
            txtRazao.Text = "";
            txtNome.Text = "";
            txtIes.Text = "";
            txtImu.Text = "";
            txtNomePro.Text = "";
            txtPreco.Text = "";
            txtQtd.Text = "";
        }

        private void frmCadPro_Load(object sender, EventArgs e)
        {
            txtPreco.Text = "0,00";
        }
    }
}
