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
    public partial class frmConsultar : Form
    {
        public frmConsultar()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //Voltar para a tela principal
            frmPrincipal principal = new frmPrincipal();
            principal.Show();
            //Esconder essa tela
            this.Hide();
        }
    }
}
