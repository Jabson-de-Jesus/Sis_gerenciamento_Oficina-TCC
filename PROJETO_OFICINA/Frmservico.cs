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
    public partial class Frmservico : Form
    {
        public Frmservico()
        {
            InitializeComponent();
        }

        private char OP = 'V';

        private void Frmservico_Load_1(object sender, EventArgs e)
        {

            CAMADAS.DAL.Servicos dalserv = new CAMADAS.DAL.Servicos();
            dtgservicos.DataSource = dalserv.Select();
            habilitacampos(false);

        }

        private void habilitacampos(bool status)
        {
            btninserir.Enabled = !status;
            btngravar.Enabled = status;
            btneditar.Enabled = !status;
            btnexcluir.Enabled = !status;
            btncancelar.Enabled = status;
            dtgservicos.Enabled = !status;



            txtid.Enabled = false;
            txtnome.Enabled = status;
            txtvalor.Enabled = status;
            txtobservacao.Enabled = status;
            



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

        private void btngravar_Click(object sender, EventArgs e)
        {
            {


                CAMADAS.MODEL.Servicos serv = new CAMADAS.MODEL.Servicos();
                CAMADAS.DAL.Servicos dalserv = new CAMADAS.DAL.Servicos();

                serv.id = Convert.ToInt32(txtid.Text);
                serv.nome = txtnome.Text;
                serv.valor_unit = Convert.ToInt32(txtvalor.Text);
                serv.observacao = txtobservacao.Text;




                if (txtnome.Text == string.Empty && txtobservacao.Text == string.Empty)
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
                            dalserv.Insert(serv);
                        else
                        {

                            dalserv.Update(serv);
                        }
                    }

                    dtgservicos.DataSource = dalserv.Select();

                    OP = 'V';
                    habilitacampos(false);


                    txtid.Text = "00";
                    txtnome.Text = "";
                    txtvalor.Text = "";
                    txtobservacao.Text = "";
                    habilitacampos(false);

                }

            }
        } 

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) > 0)
            {
                CAMADAS.MODEL.Servicos serv = new CAMADAS.MODEL.Servicos();
                CAMADAS.DAL.Servicos dalserv = new CAMADAS.DAL.Servicos();

                serv.id = Convert.ToInt32(txtid.Text);
                DialogResult result;
                result = MessageBox.Show("Deseja Remover o cliente Selecionado?",
                                          "Remover Cliente",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dalserv.Delete(serv);
                    MessageBox.Show("Serviços Removido com Sucesso...");
                }
                else MessageBox.Show("Não confirmada Remoção de Serviços...", "Remover");


                dtgservicos.DataSource = dalserv.Select(); //atualizar lista de registro
                habilitacampos(false);
            }
            else MessageBox.Show("Não há registro Selecionado", "Remover");


            txtid.Text = "00";
            txtnome.Text = "";
            txtvalor.Text = "";
            txtobservacao.Text = "";
            OP = 'V';
            habilitacampos(false);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtid.Text = "00";
            txtnome.Text = "";
            txtvalor.Text = "";
            txtobservacao.Text = "";

            OP = 'V';
            habilitacampos(false);
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            OP = 'I';
            habilitacampos(true);
        }

        private void dtgservicos_DoubleClick(object sender, EventArgs e)
        {
            if (dtgservicos.SelectedRows.Count > 0)
            {
                txtid.Text = dtgservicos.SelectedRows[0].Cells["id"].Value.ToString();
                txtnome.Text = dtgservicos.SelectedRows[0].Cells["nome"].Value.ToString();
                txtvalor.Text = dtgservicos.SelectedRows[0].Cells["valor_unit"].Value.ToString();
                txtobservacao.Text = dtgservicos.SelectedRows[0].Cells["observacao"].Value.ToString();
            }
            if (txtnome.Text != string.Empty)
            {

                btncancelar.Enabled = true;
                btninserir.Enabled = false;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
