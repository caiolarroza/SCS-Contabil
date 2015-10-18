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
    public partial class frmCadastrar : Form
    {
        public frmCadastrar()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //Volta para tela principal
            frmPrincipal principal = new frmPrincipal();
            principal.Show();
            //Esconder essa tela
            this.Hide();
        }

        private void frmCadastrar_Load(object sender, EventArgs e)
        {
        }
    }
}
