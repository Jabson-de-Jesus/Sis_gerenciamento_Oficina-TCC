using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO_OFICINA
{
    public partial class Frmmenu : Form
    {
        public Frmmenu()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcliente frmcli = new Frmcliente();
            frmcli.Show();
        }

        private void automovelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmautomovel frmauto = new Frmautomovel();
            frmauto.Show();
        }

        private void fucionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfuncionario frmfunc = new Frmfuncionario();
            frmfunc.Show(); 
        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmmaterial frmmat = new Frmmaterial();
            frmmat.Show();
        }

        private void serviçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmservico frmserv = new Frmservico();
            frmserv.Show();
        }

        private void orçarmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrcamentos frmorcam = new FrmOrcamentos();
            frmorcam.Show();
        }

        private void ordemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmordemdeservico frmordemservico = new Frmordemdeservico();
            frmordemservico.Show();

        }
    }
}
