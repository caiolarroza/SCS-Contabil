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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e){
            //Sair do programa
            Application.Exit();
        }

        private void testar_nivel() {
            //abrir conexão
            Conexao conexao = new Conexao();
            conexao.abrir();
            //Instancia da classe frmLogin para pegar a informação do nome do usuario
            frmLogin login = new frmLogin();
            //busca tipo do usuario
            MySqlCommand comandos = new MySqlCommand("select UsuTip from usuario where UsuNom = ?usuario", conexao.con);
            comandos.Parameters.Add(new MySqlParameter("?usuario", login.getUsuario()));
            //É executado e lido o comando.
            MySqlDataReader reader = comandos.ExecuteReader();
            String resultado = null;
            //vai ler o resultado do tipo do usuario
            while (reader.Read()){
                resultado = reader["UsuTip"].ToString();
            }
            //Se o usuario estiver nivel abaixo de A ele terá limitações
            if (resultado == "C") { 
                //bloqueia todos os botões de cadastro
                btnCadUsu.Enabled = false;
                btnCadPro.Enabled = false;
                btnCadFor.Enabled = false;
            }else if(resultado == "B"){
                //bloqueia o cadastro de usuarios
                btnCadUsu.Enabled = false;
            }
            conexao.fechar();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            testar_nivel();
        }

        private void btnCadUsu_Click(object sender, EventArgs e)
        {   //Instancia do form frmCadUsu
            frmCadUsu CadUsu = new frmCadUsu();
            //mostra o form frmCadUsu e fecha esse
            CadUsu.Show();
            this.Hide();
        }

        private void btnCadFor_Click(object sender, EventArgs e)
        {   //Instancia do form frmCadFor
            frmCadFor cadfor = new frmCadFor();
            //mostra o form frmCadFor e fecha esse
            cadfor.Show();
            this.Hide();

        }
    }
}
