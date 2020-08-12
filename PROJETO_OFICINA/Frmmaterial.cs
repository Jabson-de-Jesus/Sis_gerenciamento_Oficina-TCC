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
    public partial class Frmmaterial : Form
    {
        public Frmmaterial()
        {
            InitializeComponent();
        }

          private char OP = 'V';

        private void Frmmaterial_Load(object sender, EventArgs e)
        {
            CAMADAS.DAL.Material dalmat = new CAMADAS.DAL.Material();
            dtgmateriais.DataSource = dalmat.Select();
            habilitacampos(false);
        }

        private void habilitacampos(bool status)
        {
            btninserir.Enabled = !status;
            btngravar.Enabled = status;
            btneditar.Enabled = !status;
            btnexcluir.Enabled = !status;
            btncancelar.Enabled = status;
            dtgmateriais.Enabled = !status;



            txtid.Enabled = false;
            txtnome.Enabled = status;
            txtqtde.Enabled = status;
            txtpeso.Enabled = status;
            txtvalor.Enabled = status;
            txtoberservacao.Enabled = status;



        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            OP = 'I';
            habilitacampos(true);
        }

        private void btngravar_Click(object sender, EventArgs e)
        {

            CAMADAS.MODEL.Materiais mat = new CAMADAS.MODEL.Materiais();
            CAMADAS.DAL.Material dalmat = new CAMADAS.DAL.Material();

            mat.id= Convert.ToInt32(txtid.Text);
            mat.nome = txtnome.Text;
            mat.quantidade=Convert.ToInt32(txtqtde.Text);
            mat.peso = txtpeso.Text;
            mat.valor= Convert.ToSingle(txtvalor.Text);
            mat.observacao= txtoberservacao.Text;
            




            if (txtnome.Text == string.Empty && txtvalor.Text  == string.Empty)
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
                        dalmat.Insert(mat);
                    else
                    {

                        dalmat.Update(mat);
                    }
                }

                dtgmateriais.DataSource = dalmat.Select();

                OP = 'V';
                habilitacampos(false);


                txtid.Text = "00";
                txtnome.Text = "";
                txtqtde.Text = "";
                txtpeso.Text = "";
                txtvalor.Text = "";
                txtoberservacao.Text = ""; 
                habilitacampos(false);

            }
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

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) > 0)
            {
                CAMADAS.MODEL.Materiais mat= new CAMADAS.MODEL.Materiais();
                CAMADAS.DAL.Material dalmat = new CAMADAS.DAL.Material();

                mat.id = Convert.ToInt32(txtid.Text);
                DialogResult result;
                result = MessageBox.Show("Deseja Remover o cliente Selecionado?",
                                          "Remover Cliente",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dalmat.Delete(mat);
                    MessageBox.Show("Material removido com Sucesso...");
                }
                else MessageBox.Show("Não confirmada Remoção do ...", "Remover");


                dtgmateriais.DataSource = dalmat.Select(); //atualizar lista de registro
                habilitacampos(false);
            }
            else MessageBox.Show("Não há registro Selecionado", "Remover");


            txtid.Text = "00";
            txtnome.Text = "";
            txtqtde.Text = "";
            txtpeso.Text = "";
            txtvalor.Text = "";
            txtoberservacao.Text = "";
            OP = 'V';
            habilitacampos(false);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            {

                txtid.Text = "00";
                txtnome.Text = "";
                txtqtde.Text = "";
                txtpeso.Text = "";
                txtvalor.Text = "";
                txtoberservacao.Text = "";
                OP = 'V';
                habilitacampos(false);

            }
        }

        private void dtgmateriais_DoubleClick(object sender, EventArgs e)
        {
            if (dtgmateriais.SelectedRows.Count > 0)
            {
                txtid.Text = dtgmateriais.SelectedRows[0].Cells["id"].Value.ToString();
                txtnome.Text = dtgmateriais.SelectedRows[0].Cells["nome"].Value.ToString();
                txtqtde.Text = dtgmateriais.SelectedRows[0].Cells["quantidade"].Value.ToString();
                txtpeso.Text = dtgmateriais.SelectedRows[0].Cells["peso"].Value.ToString();
                txtvalor.Text = dtgmateriais.SelectedRows[0].Cells["valor"].Value.ToString();
                txtoberservacao.Text = dtgmateriais.SelectedRows[0].Cells["observacao"].Value.ToString();
            }
            if (txtnome.Text != string.Empty)
            {

                btncancelar.Enabled = true;
                btninserir.Enabled = false;

            }
        }
    }



}

