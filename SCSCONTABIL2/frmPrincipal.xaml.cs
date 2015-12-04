using System;
using System.Windows;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Wpf;
using System.Collections.Generic;

namespace SCSCONTABIL2
{
    /// <summary>
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        Conexao conexao = new Conexao();
        List<Saldo> lista = new List<Saldo>();
        public frmPrincipal()
        {
            InitializeComponent();
            testar_nivel();
        }

        private void btnCadUsu_Click(object sender, RoutedEventArgs e)
        {
            //Instancia do form frmCadUsu
            frmCadUsu CadUsu = new frmCadUsu();
            //mostra o form frmCadUsu e fecha esse
            CadUsu.Show();
            this.Close();
        }

        private void btnCadFor_Click(object sender, RoutedEventArgs e)
        {
            //Instancia do form frmCadFor
            frmCadFor cadfor = new frmCadFor();
            //mostra o form frmCadFor e fecha esse
            cadfor.Show();
            this.Close();
        }

        private void btnCadPro_Click(object sender, RoutedEventArgs e)
        {
            //Instância da classe frmCadPro
            frmCadPro cadpro = new frmCadPro();
            //mostra o form frmCadPro e fecha esse
            cadpro.Show();
            this.Close();
        }

        private void testar_nivel()
        {
            //abrir conexão
            
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
            while (reader.Read())
            {
                resultado = reader["UsuTip"].ToString();
            }
            //Se o usuario estiver nivel abaixo de A ele terá limitações
            if (resultado == "USER")
            {
                //bloqueia todos os botões de cadastro
                btnCadUsu.IsEnabled = false;
                btnCadPro.IsEnabled = false;
                btnCadFor.IsEnabled = false;
            }
            else if (resultado == "ADMIN")
            {
                //bloqueia o cadastro de usuarios
                btnCadUsu.IsEnabled = false;
            }
            conexao.fechar();
        }

        private void btnConFor_Click(object sender, RoutedEventArgs e)
        {
            //Instância da classe frmConFor
            frmConFor confor = new frmConFor();
            //mostra o form frmConFor e fecha esse
            confor.Show();
            this.Close();
        }

        private void btnConPro_Click(object sender, RoutedEventArgs e)
        {
            //Instância da classe frmConPro
            frmConProd conpro = new frmConProd();
            //mostra o form frmConPro e fecha esse
            conpro.Show();
            this.Close();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            //fecha o programa
            Application.Current.Shutdown();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //Instancia do form frmPrincipal
            frmLogin login = new frmLogin();
            //mostra o form frmPrincipal e fecha esse
            login.Show();
            this.Close();
        }

        private void btnConUsu_Click(object sender, RoutedEventArgs e)
        {
            //Instância da classe frmConUsu
            frmConUsu conusu = new frmConUsu();
            //mostra o form frmConUsu e fecha esse
            conusu.Show();
            this.Close();
        }

        private void btnVenUEPS_Click(object sender, RoutedEventArgs e)
        {
            //Instancia do form frmVenPEPS
            frmVenUEPS ueps = new frmVenUEPS();
            //mostra o form frmPrincipal e fecha esse
            ueps.Show();
            this.Close();
        }

        private void btnvenPEPS_Click(object sender, RoutedEventArgs e)
        {
            //Instancia do form frmVenPEPS
            frmVenPEPS peps = new frmVenPEPS();
            //mostra o form frmPrincipal e fecha esse
            peps.Show();
            this.Close();
        }

        private void btnrelPEPS_Click(object sender, RoutedEventArgs e)
        {
            
            
            MySqlCommand lerPEPS = new MySqlCommand("Select * from produto inner join venda on produto.ProNom = venda.VenPro" + 
                " inner join saldo on produto.ProNom = saldo.SalProd order by produto.ProDat", conexao.con);
            conexao.abrir();
            using(MySqlDataReader leitorPEPS = lerPEPS.ExecuteReader())
            {
                while (leitorPEPS.Read())
                {
                    Saldo saldo = new Saldo();

                    saldo.dataVen = (DateTime)leitorPEPS["VenDat"];
                    saldo.VenDat = saldo.dataVen.ToShortDateString();
                    saldo.VenPro = leitorPEPS["VenPro"].ToString();
                    saldo.VenQtd = (Int32)leitorPEPS["VenQtd"];
                    saldo.VenVto = (Decimal)leitorPEPS["VenVto"];
                    saldo.VenVun = (Decimal)leitorPEPS["VenVun"];
                    saldo.SalQtd = Convert.ToInt32(leitorPEPS["SalQtd"]);
                    saldo.SalVun = (Decimal)leitorPEPS["SalVun"];
                    saldo.SalVto = (Decimal)leitorPEPS["SalVto"];
                    saldo.salProd = leitorPEPS["SalProd"].ToString();
                    saldo.dataSal = (DateTime)leitorPEPS["SalDat"];
                    saldo.SalDat = saldo.dataSal.ToShortDateString();

                    saldo.ProQtd = Convert.ToInt32(leitorPEPS["ProQtd"]);
                    saldo.dataPro = (DateTime)leitorPEPS["ProDat"];
                    saldo.ProDat = saldo.dataPro.ToShortDateString();
                    saldo.ProNom = leitorPEPS["ProNom"].ToString();
                    saldo.ProVun = (Decimal)leitorPEPS["ProPco"];
                    saldo.ProVto = (Decimal)leitorPEPS["ProPcoTot"];
                    saldo.ProFre = (Decimal)leitorPEPS["ProFre"];
                    saldo.ProIcms = (Decimal)leitorPEPS["ProIcms"];

                    
                    lista.Add(saldo);
                    
                }
                leitorPEPS.Close();
            }
            conexao.fechar();
            StiReport relatorio = new StiReport();
            relatorio.RegData("saldo", lista);
            
            relatorio.DesignWithWpf();
        }


        
    }
}
