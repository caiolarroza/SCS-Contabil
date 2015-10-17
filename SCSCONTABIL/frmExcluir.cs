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
    public partial class frmExcluir : Form
    {
        public frmExcluir()
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

        private void frmExcluir_Load(object sender, EventArgs e)
        {
        }
    }
}
