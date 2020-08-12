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
    public partial class Frmautomovel : Form
    {
        public Frmautomovel()
        {
            InitializeComponent();
        }

        private char OP = 'V';

        private void Automoveis_Load(object sender, EventArgs e)
        {
            CAMADAS.DAL.Automoveis dalauto = new CAMADAS.DAL.Automoveis();
            dtgautomoveis.DataSource = dalauto.Select();
            habilitacampos(false);
        }
        private void habilitacampos(bool status)
        {
            btninserir.Enabled = !status;
            btngravar.Enabled = status;
            btneditar.Enabled = !status;
            btnexcluir.Enabled = !status;
            btncancelar.Enabled = status;
            dtgautomoveis.Enabled = !status;



            txtid.Enabled = false;
            txtnome.Enabled = status; 
            txtmarca.Enabled = status;
            txtmarca.Enabled = status;
            txtcor.Enabled = status;
            txtplaca.Enabled = status;



        }



        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btngravar_Click(object sender, EventArgs e)
        {
            CAMADAS.MODEL.Automoveis auto = new CAMADAS.MODEL.Automoveis();
            CAMADAS.DAL.Automoveis dalauto = new CAMADAS.DAL.Automoveis();


            auto.id = Convert.ToInt32(txtid.Text);
            auto.nome = txtnome.Text;
            auto.marca = txtmarca.Text;
            auto.cor = txtcor.Text;
            auto.placa = txtplaca.Text;


            if (txtmarca.Text == string.Empty && txtcor.Text == string.Empty && txtplaca.Text == string.Empty)
            {
                MessageBox.Show("Preencha os Campos do Formulario!!!");

            }
            else
            {
                string msg;
                if (OP == 'I')
                {
                    msg = "Deseja Confirmar Inserção dos Dados?";

                }
                else msg = "Deseja Confirmar Alteração dos Dados?";

                DialogResult resp;
                resp = MessageBox.Show(msg, "Gravar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (resp == DialogResult.OK)
                {
                    if (OP == 'I')
                        dalauto.Insert(auto);
                    else
                    if(OP == 'E')
                    {

                        dalauto.Update(auto);
                    }
                }

                dtgautomoveis.DataSource = dalauto.Select();

                OP = 'V';
                


                txtid.Text = "00";
                txtnome.Text = "";
                txtmarca.Text = "";
                txtcor.Text = "";
                txtplaca.Text = "";
                habilitacampos(false);
            }

        }


        private void btninserir_Click(object sender, EventArgs e)
        {
            OP = 'I';
            habilitacampos(true);
            txtnome.Focus();

        }

        private void dtgautomoveis_DoubleClick(object sender, EventArgs e)
        {
            if (dtgautomoveis.SelectedRows.Count > 0)
            {
                txtid.Text = dtgautomoveis.SelectedRows[0].Cells["id"].Value.ToString();
                txtnome.Text = dtgautomoveis.SelectedRows[0].Cells["nome"].Value.ToString();
                txtmarca.Text = dtgautomoveis.SelectedRows[0].Cells["marca"].Value.ToString();
                txtcor.Text = dtgautomoveis.SelectedRows[0].Cells["cor"].Value.ToString();
                txtplaca.Text = dtgautomoveis.SelectedRows[0].Cells["placa"].Value.ToString();
                
            }
            if (txtmarca.Text != string.Empty)
            {

                btncancelar.Enabled = true;
                btninserir.Enabled = false;

            }
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtid.Text) > 0)
            {
                CAMADAS.MODEL.Automoveis auto = new CAMADAS.MODEL.Automoveis();
                CAMADAS.DAL.Automoveis dalauto = new CAMADAS.DAL.Automoveis();

                auto.id = Convert.ToInt32(txtid.Text);
                DialogResult result;
                result = MessageBox.Show("Deseja Remover?",
                                          "Remover",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dalauto.Delete(auto);
                    MessageBox.Show("Removido com Sucesso...");
                }
                else MessageBox.Show("Não confirmada Remoção...", "Remover");


                dtgautomoveis.DataSource = dalauto.Select(); //atualizar lista de registro
                habilitacampos(false);
            }
            else MessageBox.Show("Não há registro Selecionado", "Remover");


            txtid.Text = "00";
            txtmarca.Text = "";
            txtmarca.Text = "";
            txtcor.Text = "";
            txtplaca.Text = "";
            OP = 'V';
            habilitacampos(false);

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtid.Text = "00";
            txtmarca.Text = "";
            txtmarca.Text = "";
            txtcor.Text = "";
            txtplaca.Text = "";
            OP = 'V';
            habilitacampos(false);
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) > 0)
            {
                OP = 'E';
                habilitacampos(true);


            }
            else
            {
                MessageBox.Show("Não há registros Selecionado");
            }
        }
    }
}