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
using Correios.Net;
namespace SCSCONTABIL
{
    public partial class frmConFor : Form
    {
        //variavel de codigo do endereco e telefone do fornecedor
        int endereco = 0, telefone = 0;
        //pega o codigo do produto
        int codigo = 0;
    //instância da classe conexao
    Conexao conexao = new Conexao();

        public frmConFor()
        {
            InitializeComponent();
        }

        private void frmConFor_Load(object sender, EventArgs e)
        {
            //carrega os dados do BD no dataGrid
            atualizaDataGrid();
        }









        private void atualizaDataGrid()
        {
            //carrega o datagrid com todos os produtos   
            conexao.abrir();
            //limpa o datagrid
            dataGrid.Rows.Clear();
            dataGrid.Refresh();
            MySqlCommand datagrid = new MySqlCommand("select ForCod, ForNom from fornecedor", conexao.con);
            using (MySqlDataReader leitor = datagrid.ExecuteReader())
            {
                while (leitor.Read())
                {
                    //adiciona os campos do BD ao datagrid
                    dataGrid.Rows.Add(leitor["ForCod"].ToString(), leitor["ForNom"].ToString());
                }
            }
            conexao.fechar();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //pega a linha selecionada no datagrid
            int linha = dataGrid.CurrentCell.RowIndex;
            //pega o codigo do produto
            codigo = Convert.ToInt32(dataGrid.Rows[linha].Cells["Codigo"].Value);
            //informações do produto
            MySqlCommand buscaFor = new MySqlCommand("select * from fornecedor where ForCod = ?codigo", conexao.con);
            buscaFor.Parameters.Add(new MySqlParameter("?codigo", codigo));


            //abrir conexao
            conexao.abrir();
            //ler as informações do produto
            using (MySqlDataReader leitor = buscaFor.ExecuteReader())
            {
                while (leitor.Read())
                {
                    txtRazao.Text = leitor["ForRaz"].ToString();
                    txtNome.Text = leitor["ForNom"].ToString();
                    txtCnpj.Text = leitor["ForCnp"].ToString();
                    txtImu.Text = leitor["ForImu"].ToString();
                    txtIes.Text = leitor["ForIes"].ToString();
                    telefone = Convert.ToInt32(leitor["ForTel"]);
                    endereco = Convert.ToInt32(leitor["ForEnd"]);
                }

            }

            //informações do endereço do fornecedor
            MySqlCommand buscaEnd = new MySqlCommand("select * from endereco where EndCod = ?codigo", conexao.con);
            buscaEnd.Parameters.Add(new MySqlParameter("?codigo", endereco));

            using (MySqlDataReader leitor = buscaEnd.ExecuteReader())
            {
                while (leitor.Read())
                {
                    txtEnd.Text = leitor["EndEnd"].ToString();
                    txtNumEnd.Text = leitor["EndNum"].ToString();
                    txtCom.Text = leitor["EndCom"].ToString();
                    txtBai.Text = leitor["EndBai"].ToString();
                    txtMun.Text = leitor["EndMun"].ToString();
                    txtEst.Text = leitor["EndEst"].ToString();
                    txtCep.Text = leitor["EndCep"].ToString();
                }
            }

            //informações do telefone do fornecedor
            MySqlCommand buscaTel = new MySqlCommand("select * from telefone where TelCod = ?codigo", conexao.con);
            buscaTel.Parameters.Add(new MySqlParameter("?codigo", telefone));

            using (MySqlDataReader leitor = buscaTel.ExecuteReader())
            {
                while (leitor.Read())
                {
                    txtDdd.Text = leitor["TelDdd"].ToString();
                    txtNumTel.Text = leitor["TelNum"].ToString();
                    
                }
            }
            conexao.fechar();
        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            if (txtCep.TextLength == 9)
            {
                //Envia o CEP ao metodo busca
                busca(txtCep.Text);
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "CEP Invalido";
                txtCep.Text = "";
                txtCep.Focus();
            }
        }



        public void busca(string cep)
        {
            try
            {

                //uso da API Correios.Net
                //https://github.com/hamboldt/Correios.Net
                //Faz a pesquisa na base de dados dos correios usando o cep
                Address address = SearchZip.GetAddress(cep, 5000);

                if (address.Street != "Não encontrado")
                {
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "";
                    //atribuir a informação aos campos
                    txtEnd.Text = address.Street;
                    txtBai.Text = address.District;
                    txtMun.Text = address.City;
                    txtEst.Text = address.State;
                    txtNumEnd.Focus();
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "CEP Invalido";
                    txtCep.Text = "";
                    txtCep.Focus();

                }
            }
            catch (System.Net.WebException erro)
            {
                //esse catch será executado especificamente quando não tiver conexão com a web
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Impossivel pesquisar enquanto offline. Preencha os dados manualmente";
            }
            catch (Exception e)
            {
                //catch genérico 
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = e.Message;
            }

        }

        private void limpar()
        {
            txtRazao.Text = "";
            txtNome.Text = "";
            txtCnpj.Text = "";
            txtImu.Text = "";
            txtIes.Text = "";
            txtDdd.Text = "";
            txtNumTel.Text = "";
            txtCep.Text = "";
            txtEnd.Text = "";
            txtNumEnd.Text = "";
            txtCom.Text = "";
            txtBai.Text = "";
            txtMun.Text = "";
            txtEst.Text = "";
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (txtRazao.Text.Equals("") || txtNome.Text.Equals("") ||
                txtCnpj.Text.Equals("") || txtImu.Text.Equals("") ||
                txtIes.Text.Equals("") || txtDdd.Text.Equals("") ||
                txtNumTel.Text.Equals("") || txtCep.Text.Equals("") ||
                txtEnd.Text.Equals("") || txtNumEnd.Text.Equals("") ||
                txtBai.Text.Equals("") || txtMun.Text.Equals("") ||
                txtEst.Text.Equals(""))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preencha todos os campos com *";
            }
            else
            {
                atualizarDados();
            }
        }

        private void btnVol_Click(object sender, EventArgs e)
        {
            //instância da classe frmPrincipal
            frmPrincipal frmpri = new frmPrincipal();
            //Fecha esse form e abre o frmPrincipal
            frmpri.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtRazao.Text.Equals("") || txtNome.Text.Equals("") ||
                txtCnpj.Text.Equals("") || txtImu.Text.Equals("") ||
                txtIes.Text.Equals("") || txtDdd.Text.Equals("") ||
                txtNumTel.Text.Equals("") || txtCep.Text.Equals("") ||
                txtEnd.Text.Equals("") || txtNumEnd.Text.Equals("") ||
                txtBai.Text.Equals("") || txtMun.Text.Equals("") ||
                txtEst.Text.Equals(""))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preencha todos os campos com *";
            }
            else
            {
                deletarDados();
            }
        }

        private void atualizarDados()
        {
            try
            {
                //atualiza as informações do fornecedor
                conexao.abrir();

                MySqlCommand alterarFor = new MySqlCommand("update fornecedor set ForRaz = ?razao, ForNom = ?nome, ForCnp = ?cnpj, " +
                    "ForImu = ?imu, ForIes = ?ies where ForCod = ?codigo", conexao.con);
                alterarFor.Parameters.Add(new MySqlParameter("?razao", txtRazao.Text));
                alterarFor.Parameters.Add(new MySqlParameter("?nome", txtNome.Text));
                alterarFor.Parameters.Add(new MySqlParameter("?cnpj", txtCnpj.semFormato()));
                alterarFor.Parameters.Add(new MySqlParameter("?imu", txtImu.semFormato()));
                alterarFor.Parameters.Add(new MySqlParameter("?ies", txtIes.semFormato()));
                alterarFor.Parameters.Add(new MySqlParameter("?codigo", codigo));
                alterarFor.ExecuteNonQuery();

                MySqlCommand alterarTel = new MySqlCommand("update telefone set TelDdd = ?ddd, TelNum = ?numero where TelCod = ?codigo", conexao.con);
                alterarTel.Parameters.Add(new MySqlParameter("?ddd", txtDdd.semFormato()));
                alterarTel.Parameters.Add(new MySqlParameter("?numero", txtNumTel.semFormato()));
                alterarTel.Parameters.Add(new MySqlParameter("?codigo", telefone));
                alterarTel.ExecuteNonQuery();

                MySqlCommand alterarEnd = new MySqlCommand("update endereco set EndEnd = ?end, EndNum = ?num, EndCom = ?complemento, " +
                    "EndBai = ?bairro, EndMun = ?municipio, EndEst = ?estado, EndCep = ?cep where EndCod = ?codigo", conexao.con);
                alterarEnd.Parameters.Add(new MySqlParameter("?end", txtEnd.Text));
                alterarEnd.Parameters.Add(new MySqlParameter("?num", txtNumEnd.Text));
                alterarEnd.Parameters.Add(new MySqlParameter("?complemento", txtCom.Text));
                alterarEnd.Parameters.Add(new MySqlParameter("?bairro", txtBai.Text));
                alterarEnd.Parameters.Add(new MySqlParameter("?municipio", txtMun.Text));
                alterarEnd.Parameters.Add(new MySqlParameter("?estado", txtEst.Text));
                alterarEnd.Parameters.Add(new MySqlParameter("?cep", txtCep.semFormato()));
                alterarEnd.Parameters.Add(new MySqlParameter("?codigo", endereco));
                alterarEnd.ExecuteNonQuery();

                conexao.fechar();
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Alterado com sucesso";
                limpar();
                atualizaDataGrid();
                dataGrid.Focus();

            }
            catch (Exception erro)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;

            }
        }

        private void txtCnpj_Click(object sender, EventArgs e)
        {
            if (txtCnpj.Text.Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtCnpj.SelectionStart = 0;
                txtCnpj.ScrollToCaret();
            }

        }

        private void txtImu_Click(object sender, EventArgs e)
        {
            if (txtImu.Text.Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtImu.SelectionStart = 0;
                txtImu.ScrollToCaret();
            }
        }

        private void txtIes_Click(object sender, EventArgs e)
        {
            if (txtIes.Text.Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtIes.SelectionStart = 0;
                txtIes.ScrollToCaret();
            }
        }

        private void txtDdd_Click(object sender, EventArgs e)
        {
            if (txtDdd.Text.Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtDdd.SelectionStart = 0;
                txtDdd.ScrollToCaret();
            }
        }

        private void txtNumTel_Click(object sender, EventArgs e)
        {
            if (txtNumTel.Text.Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtNumTel.SelectionStart = 0;
                txtNumTel.ScrollToCaret();
            }
        }

        private void txtCep_Click(object sender, EventArgs e)
        {
            if (txtCep.Text.Equals(""))
            {
                //faz o masked textbox iniciar sempre no primeiro caracter
                txtCep.SelectionStart = 0;
                txtCep.ScrollToCaret();
            }
        }

        private void deletarDados()
        {
            try
            {
                //confirma se o usuario vai excluir o fornecedor
                DialogResult op = MessageBox.Show("Tem certeza que deseja excluir o fornecedor: " + txtNome.Text + "?", "Excluir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (op.ToString().ToUpper() == "YES")
                {

                    conexao.abrir();

                    MySqlCommand deletarFor = new MySqlCommand("delete from fornecedor where ForCod = ?codigo", conexao.con);
                    deletarFor.Parameters.Add(new MySqlParameter("?codigo", codigo));                    
                    deletarFor.ExecuteNonQuery();

                    MySqlCommand deletarEnd = new MySqlCommand("delete from endereco where EndCod = ?codigo", conexao.con);
                    deletarEnd.Parameters.Add(new MySqlParameter("?codigo", endereco));
                    deletarEnd.ExecuteNonQuery();

                    MySqlCommand deletarTel = new MySqlCommand("delete from telefone where TelCod = ?codigo", conexao.con);
                    deletarTel.Parameters.Add(new MySqlParameter("?codigo", telefone));
                    deletarTel.ExecuteNonQuery();

                    conexao.fechar();
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Deletado com sucesso";
                    limpar();
                    atualizaDataGrid();
                    dataGrid.Focus();
                }
            }
            catch (Exception erro)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = erro.Message;
            }
        }
    }
}
