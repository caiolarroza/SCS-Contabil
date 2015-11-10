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
    public partial class frmConProd : Form
    {
        Conexao conexao = new Conexao();
        public frmConProd()
        {
            InitializeComponent();
        }

        private void frmConProd_Load(object sender, EventArgs e)
        {
            atualizaDataGrid();
        }

        private void dataGrid_Click(object sender, EventArgs e)
        {
            
        }
        

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            //chama o metodo que formatara o valor
            Moeda(ref txtPreco);
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

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //variavel de codigo do fornecedor
            int forne = 0;
            //pega a linha selecionada no datagrid
            int linha = dataGrid.CurrentCell.RowIndex;
            //pega o codigo do produto
            int codigo = Convert.ToInt32(dataGrid.Rows[linha].Cells["Codigo"].Value);
            //informações do produto
            MySqlCommand buscaProd = new MySqlCommand("select * from produto where ProCod = ?codigo", conexao.con);
            buscaProd.Parameters.Add(new MySqlParameter("?codigo", codigo));

           
            //abrir conexao
            conexao.abrir();
            //ler as informações do produto
            using (MySqlDataReader leitor = buscaProd.ExecuteReader())
            {
                while (leitor.Read())
                {
                    txtNomePro.Text = leitor["ProNom"].ToString();
                    txtData.Text = leitor["ProDat"].ToString();
                    txtPreco.Text = leitor["ProPco"].ToString();
                    txtQtd.Text = leitor["ProQtd"].ToString();
                    forne = Convert.ToInt32(leitor["ProFor"]);
                    txtCod.Text = codigo.ToString();
                }

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
            }
            conexao.fechar();
        }

        private void btnVol_Click(object sender, EventArgs e)
        {
            //instância da classe frmPrincipal
            frmPrincipal frmpri = new frmPrincipal();
            //Fecha esse form e abre o frmPrincipal
            frmpri.Show();
            this.Close();
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            String busca = txtBusca.Text;
            //buscar os produtos conforme o nome que o usuario digitar
            MySqlCommand buscaProd = new MySqlCommand("select ProCod, ProNom from produto where ProNom like '%' ?nome '%'", conexao.con);
            buscaProd.Parameters.Add(new MySqlParameter("?nome", busca));
            //limpa o datagrid
            dataGrid.Rows.Clear();
            dataGrid.Refresh();
            conexao.abrir();
            using(MySqlDataReader leitor = buscaProd.ExecuteReader())
            {
                while (leitor.Read())
                {
                    //adiciona dados ao dataGrid
                    dataGrid.Rows.Add(leitor["ProCod"].ToString(), leitor["ProNom"].ToString());
                }
            }
            txtBusca.Text = "";
            conexao.fechar();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtRazao.Text.Equals("") || txtNomePro.Text.Equals("") || txtPreco.Text.Equals("") ||
                txtQtd.Text.Equals(""))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preencha todos os campos com *";
            }
            else
            {
                deletarDados();
            }
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (txtRazao.Text.Equals("") || txtNomePro.Text.Equals("") || txtPreco.Text.Equals("") ||
                txtQtd.Text.Equals(""))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preencha todos os campos com *";
            }
            else
            {
                atualizarDados();
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

        private void limpar()
        {
            
            txtRazao.Text = "";
            txtBusca.Text = "";
            txtNome.Text = "";
            txtIes.Text = "";
            txtImu.Text = "";
            txtCod.Text = "";
            txtNomePro.Text = "";
            txtPreco.Text = "";
            txtData.Text = "";
            txtQtd.Text = "";
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


        private void deletarDados()
        {
            try
            {
                //confirma se o usuario vai excluir o produto
                DialogResult op = MessageBox.Show("Tem certeza que deseja excluir o produto: " + txtNomePro.Text + "?", "Excluir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (op.ToString().ToUpper() == "YES")
                {
                    MySqlCommand deletar = new MySqlCommand("delete from produto where ProCod = ?codigo", conexao.con);
                    deletar.Parameters.Add(new MySqlParameter("?codigo", txtCod.Text));
                    conexao.abrir();
                    deletar.ExecuteNonQuery();
                    conexao.fechar();
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Deletado com sucesso";
                    limpar();
                    atualizaDataGrid();
                    txtBusca.Focus();
                }
            }
            catch (Exception erro)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;
            }
        }


        private void atualizarDados()
        {
            try
            {

                String preco = txtPreco.Text.Replace(".", "").Replace(",", ".");
                MySqlCommand alterar = new MySqlCommand("update produto set ProNom = ?nome, ProPco = ?preco, ProQtd = ?qtd " +
                    "where ProCod = ?codigo", conexao.con);
                alterar.Parameters.Add(new MySqlParameter("?nome", txtNomePro.Text));
                alterar.Parameters.Add(new MySqlParameter("?preco", preco));
                alterar.Parameters.Add(new MySqlParameter("?qtd", txtQtd.Text));
                alterar.Parameters.Add(new MySqlParameter("?codigo", txtCod.Text));
                conexao.abrir();
                alterar.ExecuteNonQuery();
                conexao.fechar();
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Alterado com sucesso";
                limpar();
                atualizaDataGrid();
                txtBusca.Focus();

            }
            catch (Exception erro)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;
                MessageBox.Show(erro.ToString());
            }
        }


        private void atualizaDataGrid()
        {
            //carrega o datagrid com todos os produtos   
            conexao.abrir();
            //limpa o datagrid
            dataGrid.Rows.Clear();
            dataGrid.Refresh();
            MySqlCommand datagrid = new MySqlCommand("select ProCod, ProNom from produto", conexao.con);
            using (MySqlDataReader leitor = datagrid.ExecuteReader())
            {
                while (leitor.Read())
                {
                    //adiciona os campos do BD ao datagrid
                    dataGrid.Rows.Add(leitor["ProCod"].ToString(), leitor["ProNom"].ToString());
                }
            }
            conexao.fechar();
        }

        
    }
}

