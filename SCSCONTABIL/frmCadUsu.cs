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
    public partial class frmCadUsu : Form
    {
        //codigo de cadastro do novo usuario
        public int codUsuarios = 1;
        //Informações do cadastro
        private static String usuario, senha, tipoUsu;
        //Instancia da classe Conexao
        Conexao conexao = new Conexao();
        
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
                //abrir conexao BD
                conexao.abrir();
                //Variavel com os comandos de consulta do nome
                MySqlCommand consultaNome = new MySqlCommand("select * from usuario where UsuNom = ?usuario", conexao.con);
                //adiciona parametros ao comando String, evita problemas com SQL Inject
                consultaNome.Parameters.Add(new MySqlParameter("?usuario", usuario));
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
                    //Variavel com os comandos de consulta do codigo
                    MySqlCommand consultaCod = new MySqlCommand("select * from usuario where UsuCod = ?codigo ", conexao.con);
                    //adiciona parametros ao comando String, evita problemas com SQL Inject
                    consultaCod.Parameters.Add(new MySqlParameter("?codigo", codUsuarios));
                    //É executado e lido o comando.
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
                //Variavel com os comandos de consulta do codigo
                MySqlCommand cadastroUsu = new MySqlCommand("insert into usuario values( ?codigo, ?usuario, ?senha , ?tipo)", conexao.con);
                //adiciona parametros ao comando String, evita problemas com SQL Inject
                cadastroUsu.Parameters.Add(new MySqlParameter("?codigo", codUsuarios));
                cadastroUsu.Parameters.Add(new MySqlParameter("?usuario", usuario));
                cadastroUsu.Parameters.Add(new MySqlParameter("?senha", senha));
                cadastroUsu.Parameters.Add(new MySqlParameter("?tipo", tipoUsu));
                //Aqui é executado
                cadastroUsu.ExecuteNonQuery();
                //muda a cor do label para verde e avisa o usuario
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Usuario cadastrado com sucesso";
                //limpa os campos e foca no txt de Usuario
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
