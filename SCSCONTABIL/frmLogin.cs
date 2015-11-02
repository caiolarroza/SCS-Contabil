//bibliotecas:
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
    public partial class frmLogin : Form
    {
        static string buscaUser;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Nenhum comando a ser executado durante o evento Load.
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Ao clicar no botão entrar, o método "efetuar_login" é chamado.
            efetuar_login();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Ao clicar no botão sair, a aplicação toda se fecha através do comando abaixo.
            Application.Exit();
        }

        private void efetuar_login()
        {
            //Verifica se o campo de usuário está vazio.
            if (txtUsuario.Text.Equals(""))
            {
                //Manda uma mensagem ao usuário.
                lblStatus.Text = "Digite o usuário";
                //Seta o foco no textbox Usuario.
                txtUsuario.Focus();
            }
            else
            {
                //Verifica se o campo de senha está vazio.
                if (txtSenha.Text.Equals(""))
                {
                    //Manda uma mensagem ao usuário.
                    lblStatus.Text = "Digite a senha";
                    //Seta o foco no textbox Senha.
                    txtSenha.Focus();
                }
                else
                {
                    //A variavel do tipo Conexao recebe a classe Conexao.
                    Conexao conexao = new Conexao();

                    try
                    {
                        //Pega o usuário digitado. 
                        String user = txtUsuario.Text;
                        //Para passar a informação do user através de get e set
                        buscaUser = user;
                        //Pega a senha digitada.
                        String senha = txtSenha.Text;
                        //Abre a conexão com o banco de dados.
                        conexao.abrir();
                        //Seleciona todos os dados da tabela usuário onde o nome for igual ao digitado e a senha igual a digitada.
                        MySqlCommand comandos = new MySqlCommand("select * from usuario where UsuNom = ?user and UsuSen = ?senha", conexao.con);
                        //adiciona parametros ao comando, evita problemas com SQL Inject
                        comandos.Parameters.Add(new MySqlParameter("?user", user));
                        comandos.Parameters.Add(new MySqlParameter("?senha", senha));
                        //É executado e lido o comando.
                        MySqlDataReader reader = comandos.ExecuteReader();

                        //Se existir dados:
                        if (reader.HasRows)
                        {
                            conexao.fechar();
                            //Chama o formulário principal;
                            frmPrincipal principal = new frmPrincipal();
                            principal.Show();
                            //Esconde este formulário (frmLogin).
                            this.Hide();
                        }
                        else
                        {
                            //Se não existirem dados, é mandado uma mensagem.
                            lblStatus.Text = "Informações Incorretas";
                            //Os campos de senha e usuario ficam vazios:
                            txtUsuario.Text = "";
                            txtSenha.Text = "";
                            //O campo senha recebe foco.
                            txtUsuario.Focus();
                        }
                    }
                    catch (Exception erro)
                    {
                        //Se algum erro ocorrer é mandado esta mensagem e a conexao com o banco de dados se fecha.
                        lblStatus.Text = erro.Message;
                        conexao.fechar();
                    }
                }
            }
        }

        

        public string getUsuario()
        {
            return buscaUser;
        }

        private void lblStatus_SizeChanged(object sender, EventArgs e)
        {
            //centraliza o label conforme o form
            lblStatus.Left = (this.ClientSize.Width - lblStatus.Size.Width) / 2;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Quando o usuário apertar enter no campo senha é chamado o método "efetuar_login".
            if (e.KeyChar == (char)13)
            {
                efetuar_login();
            }
        }
    }
}
