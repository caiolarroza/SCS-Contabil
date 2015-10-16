using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCSCONTABIL
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Abrir tela de cadastro
            frmCadastrar cadastrar = new frmCadastrar();
            cadastrar.Show();
            //Esconder essa tela
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Abrir tela de consulta
            frmConsultar consultar = new frmConsultar();
            consultar.Show();
            //Esconder essa tela
            this.Hide();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Abrir tela de exclusao
            frmExcluir excluir = new frmExcluir();
            excluir.Show();
            //Apagar essa tela
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Sair do programa
            Application.Exit();
        }
    }
}
