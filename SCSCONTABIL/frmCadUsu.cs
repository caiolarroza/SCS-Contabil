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
using System.Drawing;

namespace SCSCONTABIL
{
    public partial class frmCadUsu : Form
    {
        //codigo de cadastro do novo usuario
        public int codUsuarios = 1;
        //Informações do cadastro
        private static String usuario, senha, tipoUsu;
        //Instancia da classe Conexao
        Conexao conexao = new Conexao();
        //Variavel que receberá todos os comandos
        private static String comando;
        
        public frmCadUsu()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //Instancia do form frmPrincipal
            frmPrincipal principal = new frmPrincipal();
            //mostra o form frmPrincipal e fecha esse
            principal.Show();
            this.Hide();
        }
        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //receber dados dos textBox
            usuario = txtUsu.Text;
            senha = txtSen.Text;
            //converter a opção do comboBox para string
            tipoUsu = Convert.ToString(cmbTipo.SelectedItem);
            if (tipoUsu.Equals("") || usuario.Equals("") || senha.Equals(""))
            {   //reinicia os valores                             
                txtUsu.Text = "";
                txtSen.Text = "";
                cmbTipo.SelectedIndex = -1;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preencha todos os campos";
            }
            else
            {
                //metodo verifica se o nome ja está em uso
                verificar_nome();

            }
        }

        private void frmCadUsu_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUsu_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void verificar_nome()
        {
            try {

                //Instancia da classe Conexao

                //abrir conexao BD
                conexao.abrir();
                comando = "select * from usuario where UsuNom = '" + usuario + "'";
                //A variavel comando é mandada para execução no caminho declarado na classe conexao.
                //Variavel que lerá os comandos de consulta do nome
                MySqlCommand consultaNome = new MySqlCommand(comando, conexao.con);
                //Variavel que executará as leituras
                using (MySqlDataReader readerNome = consultaNome.ExecuteReader())
                {
                    //verificar se o nome ja está em uso
                    if (readerNome.HasRows)
                    {   //se estiver em uso ele avisa o usuário
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Usuário já cadastrado";
                        txtUsu.Text = "";
                        txtSen.Text = "";
                        cmbTipo.SelectedIndex = -1;
                        txtUsu.Focus();
                        conexao.fechar();
                    }
                    else
                    {
                        //fechar reader
                        readerNome.Close();
                        //fechar conexao
                        conexao.fechar();
                        verificar_codigo();
                        
                    }
                }
            }catch(Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.fechar();
            }
        }

        private void verificar_codigo()
        {

            try
            {

                //abrir conexao com BD
                conexao.abrir();
                Boolean lugar = false;

                while (lugar == false)
                {

                    comando = "select * from usuario where UsuCod = " + codUsuarios;
                    //A variavel comando é mandada para execução no caminho declarado na classe conexao.
                    //Variavel que lerá os comandos de consulta do codigo
                    MySqlCommand consultaCod = new MySqlCommand(comando, conexao.con);
                    //É executado e lido o comando.
                    //APONTA ERRO NESSA LINHA ABAIXO 
                    using (MySqlDataReader readerCod = consultaCod.ExecuteReader())
                    {
                        //verificar o primeiro lugar vago para cadastrar usuario
                        //verificar se o codigo ja está em uso
                        if (readerCod.HasRows)
                        {   //se estiver em uso procura pelo proximo
                            codUsuarios++;
                        }
                        else
                        {
                            //fechar reader
                            readerCod.Close();
                            //fechar conexao
                            conexao.fechar();
                            cadastrar();
                        }
                    }
                }
            }catch (InvalidOperationException error)
            {

            }catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.fechar();
            }
        }

        private void cadastrar()
        {
            try {
                conexao.abrir();
                comando = "insert into usuario values(" + codUsuarios + ", '" + usuario + "', '" + senha + "', '" + tipoUsu + "')";
                //o comando da string é mandada para execução
                MySqlCommand cadastroUsu = new MySqlCommand(comando, conexao.con);
                //Aqui é executado
                cadastroUsu.ExecuteNonQuery();
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Usuario cadastrado com sucesso";
                txtSen.Text = "";
                txtUsu.Text = "";
                cmbTipo.SelectedIndex = -1;
                txtUsu.Focus();
                conexao.fechar();

            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro: " + erro.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
