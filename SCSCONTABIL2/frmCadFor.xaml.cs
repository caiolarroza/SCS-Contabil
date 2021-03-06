﻿using System;
using System.Windows;
using System.Windows.Media;
using Correios.Net;
using MySql.Data.MySqlClient;
using Xceed.Wpf.Toolkit;

namespace SCSCONTABIL2
{
    /// <summary>
    /// Interaction logic for frmCadFor.xaml
    /// </summary>
    public partial class frmCadFor : Window
    {
        static private int cod = 1;
        Conexao conexao = new Conexao();
        public frmCadFor()
        {
            InitializeComponent();
            txtRazao.Focus();
            txtRazao.MaxLength = 40;
            txtNome.MaxLength = 40;
            txtEnd.MaxLength = 60;
            txtNumEnd.MaxLength = 7;
            txtCom.MaxLength = 30;
            txtBai.MaxLength = 30;
            txtMun.MaxLength = 30;
            txtEst.MaxLength = 2;
        }
        

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //verifica se os campos estão preenchidos
            if (txtRazao.Text.Equals("") || txtNome.Text.Equals("") ||
                txtCnpj.Text.Equals("") || txtImu.Text.Equals("") ||
                txtIes.Text.Equals("") || txtDdd.Text.Equals("") ||
                txtNumTel.Text.Equals("") || txtCep.Text.Equals("") ||
                txtEnd.Text.Equals("") || txtNumEnd.Text.Equals("") ||
                txtBai.Text.Equals("") || txtMun.Text.Equals("") ||
                txtEst.Text.Equals(""))
            {
                //se não estiver lança aviso ao usuario
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = "Todos os campos com * devem ser preenchidos";
            }
            else
            {
                //se estiverem todos preenchidos ele confere o campo de Complemento e
                //chama o metodo cadastrar
                if (txtCom.Equals(""))
                {
                    txtCom.Text = null;
                }
                consultar_CNPJ();

            }
        }

        private void btnCep_Click(object sender, RoutedEventArgs e)
        {
            if (txtCep.Text.Length == 9)
            {
                //Envia o CEP ao metodo busca
                busca(txtCep.Text);
            }
            else
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = "CEP Invalido";
                txtCep.Text = "";
                txtCep.Focus();
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //Instância da classe frmPrincipal
            frmPrincipal principal = new frmPrincipal();
            //Abre a tela principal e fecha essa
            principal.Show();
            this.Close();
        }
               
        public void busca(string cep)
        {
            try
            {

                //uso da API Correios.Net
                //https://github.com/hamboldt/Correios.Net
                //Faz a pesquisa na base de dados dos correios usando o cep
                Address address = SearchZip.GetAddress(cep, 4000);

                if (address.Street != "Não encontrado")
                {
                    lblStatus.Foreground = Brushes.Green;
                    lblStatus.Content = "";
                    //atribuir a informação aos campos
                    txtEnd.Text = address.Street;
                    txtBai.Text = address.District;
                    txtMun.Text = address.City;
                    txtEst.Text = address.State;
                    txtNumEnd.Focus();
                }
                else
                {
                    lblStatus.Foreground = Brushes.Red;
                    lblStatus.Content = "CEP Invalido";
                    txtCep.Text = "";
                    txtCep.Focus();

                }
            }
            catch (System.Net.WebException erro)
            {
                //esse catch será executado especificamente quando não tiver conexão com a web
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = "Impossivel pesquisar enquanto offline. Preencha os dados manualmente";
            }
            catch (Exception e)
            {
                //catch genérico 
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = e.Message;
            }

        }

        private void consultar_CNPJ()
        {
            try
            {
                //abrir conexao BD
                conexao.abrir();
                //Variavel com os comandos de consulta do cnpj
                MySqlCommand consultaCnpj = new MySqlCommand("select * from fornecedor where ForCnp = ?cnpj", conexao.con);
                //adiciona parametros ao comando String, evita problemas com SQL Inject
                consultaCnpj.Parameters.Add(new MySqlParameter("?cnpj", txtCnpj.Text));
                //Variavel que executará as leituras
                using (MySqlDataReader readerNome = consultaCnpj.ExecuteReader())
                {
                    if (readerNome.HasRows)
                    {
                        lblStatus.Content = "Fornecedor ja cadastrado";
                        limpar();
                        txtRazao.Focus();
                    }
                    else
                    {
                        //fecha o reader
                        readerNome.Close();
                        //fecha a conexao
                        conexao.fechar();
                        consultar_codigo();
                    }

                }
            }
            catch (Exception erro)
            {
                //fechar conexao
                conexao.fechar();
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
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
                    MySqlCommand consultaCod = new MySqlCommand("select * from fornecedor where ForCod = ?codigo ", conexao.con);
                    //adiciona parametros ao comando String, evita problemas com SQL Inject
                    consultaCod.Parameters.Add(new MySqlParameter("?codigo", cod));
                    //abrir conexao com BD
                    conexao.abrir();
                    //É executado e lido o comando.
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
                //fechar conexao
                conexao.fechar();
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
            }
        }
        private void cadastrar()
        {
            
            try
            {
                // abrir conexao BD
                conexao.abrir();
                //comando para inserir valores no BD
                MySqlCommand cadastroFor = new MySqlCommand("insert into fornecedor values(?cod, ?razao, ?nome, ?cnpj, " +
                    "?imu, ?ies, ?tel, ?end)", conexao.con);
                //adiciona parametros ao comando, evita problemas com SQL Inject
                cadastroFor.Parameters.Add(new MySqlParameter("?cod", cod));
                cadastroFor.Parameters.Add(new MySqlParameter("?razao", txtRazao.Text));
                cadastroFor.Parameters.Add(new MySqlParameter("?nome", txtNome.Text));
                cadastroFor.Parameters.Add(new MySqlParameter("?cnpj", txtCnpj.semFormato()));
                cadastroFor.Parameters.Add(new MySqlParameter("?imu", txtImu.semFormato()));
                cadastroFor.Parameters.Add(new MySqlParameter("?ies", txtIes.semFormato()));
                cadastroFor.Parameters.Add(new MySqlParameter("?tel", cod));
                cadastroFor.Parameters.Add(new MySqlParameter("?end", cod));

                MySqlCommand cadastroTel = new MySqlCommand("insert into telefone values(?cod, ?ddd, ?num)", conexao.con);
                //adiciona parametros ao comando, evita problemas com SQL Inject
                cadastroTel.Parameters.Add(new MySqlParameter("?cod", cod));
                cadastroTel.Parameters.Add(new MySqlParameter("?ddd", txtDdd.semFormato()));
                cadastroTel.Parameters.Add(new MySqlParameter("?num", txtNumTel.semFormato()));

                MySqlCommand cadastroEnd = new MySqlCommand("insert into endereco values(?cod, ?end, ?num, ?comp, ?bai, " +
                    "?mun, ?est, ?cep)", conexao.con);
                //adiciona parametros ao comando, evita problemas com SQL Inject
                cadastroEnd.Parameters.Add(new MySqlParameter("?cod", cod));
                cadastroEnd.Parameters.Add(new MySqlParameter("?end", txtEnd.Text));
                cadastroEnd.Parameters.Add(new MySqlParameter("?num", txtNumEnd.Text));
                cadastroEnd.Parameters.Add(new MySqlParameter("?comp", txtCom.Text));
                cadastroEnd.Parameters.Add(new MySqlParameter("?bai", txtBai.Text));
                cadastroEnd.Parameters.Add(new MySqlParameter("?mun", txtMun.Text));
                cadastroEnd.Parameters.Add(new MySqlParameter("?est", txtEst.Text));
                cadastroEnd.Parameters.Add(new MySqlParameter("?cep", txtCep.semFormato()));
                //Aqui é executado
                cadastroEnd.ExecuteNonQuery();
                cadastroTel.ExecuteNonQuery();
                cadastroFor.ExecuteNonQuery();
                //muda a cor do label para verde e avisa o usuario
                lblStatus.Foreground = Brushes.Green;

                lblStatus.Content = "Fornecedor cadastrado com sucesso";
                //limpa os campos e foca no txt da razao social
                limpar();
                txtRazao.Focus();
                conexao.fechar();

            }
            catch (Exception erro)
            {
                //fechar conexao
                conexao.fechar();
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Content = erro.Message;
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
    }
}
