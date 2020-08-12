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
    public partial class Frmfuncionario : Form
    {
        public Frmfuncionario()
        {
            InitializeComponent();
        }

        private char OP = 'V';

        private void Frmfuncionario_Load(object sender, EventArgs e)
        {
            habilitacampos(false);
            CAMADAS.DAL.Funcionarios func = new CAMADAS.DAL.Funcionarios();
            dtgfuncionario.DataSource = func.Select();
        }



        private void habilitacampos(bool status)
        {
            btninserir.Enabled = !status;
            btngravar.Enabled = status;
            btneditar.Enabled = !status;
            btnexcluir.Enabled = !status;
            btncancelar.Enabled = status;
            dtgfuncionario.Enabled = !status;



            txtid.Enabled = false;
            txtnome.Enabled = status;
            txtfuncao.Enabled = status;
            txtsalario.Enabled = status;
            




        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btngravar_Click(object sender, EventArgs e)
        {

            CAMADAS.MODEL.Funcionarios func = new CAMADAS.MODEL.Funcionarios();
            CAMADAS.DAL.Funcionarios dalfunc = new CAMADAS.DAL.Funcionarios();

            func.id = Convert.ToInt32(txtid.Text);
            func.nome = txtnome.Text;
            func.funcao = txtfuncao.Text;
            func.salario =Convert.ToInt32(txtsalario.Text);



            if (txtsalario.Text == string.Empty && txtnome.Text == string.Empty && txtfuncao.Text == string.Empty)
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
                        dalfunc.Insert(func);
                    else
                    {

                        dalfunc.Update(func);
                    }
                }

                dtgfuncionario.DataSource = dalfunc.Select();

                OP = 'V';
                habilitacampos(false);


                txtid.Text = "00";
                txtnome.Text = "";
                txtfuncao.Text = "";
                txtsalario.Text = "";
                habilitacampos(false);

               }

            }

        private void btninserir_Click(object sender, EventArgs e)
        {
            OP = 'I';
            habilitacampos(true);
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
                MessageBox.Show("Não registro Selecionado");
            }
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) > 0)
            {
                CAMADAS.MODEL.Funcionarios func = new CAMADAS.MODEL.Funcionarios();
                CAMADAS.DAL.Funcionarios dalfunc = new CAMADAS.DAL.Funcionarios();

                func.id = Convert.ToInt32(txtid.Text);

                DialogResult result;

                result = MessageBox.Show("Deseja remover o Funcionário Selecionado",
                                           "Remover Funcionário",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                        dalfunc.Delete(func);
                        MessageBox.Show("Cliente Removido com Sucesso...");

                }
                else MessageBox.Show("Não confirmada Remoção de Cliente...", "Remover");

                        dtgfuncionario.DataSource = dalfunc.Select(); //atualizar lista de registro
                        habilitacampos(false);

                }

                else MessageBox.Show("Não há registro Selecionado", "Remover");
            
                        txtid.Text = "00";
                        txtnome.Text = "";
                        txtfuncao.Text = "";
                        txtsalario.Text = "";

                        OP = 'V';
                        habilitacampos(false);

          }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtid.Text = "00";
            txtnome.Text = "";
            txtfuncao.Text = "";
            txtsalario.Text = "";
            OP = 'V';
            habilitacampos(false);
        }

        private void dtgfuncionario_DoubleClick(object sender, EventArgs e)
        {
            if (dtgfuncionario.SelectedRows.Count > 0)
            {
                txtid.Text = dtgfuncionario.SelectedRows[0].Cells["id"].Value.ToString();
                txtnome.Text = dtgfuncionario.SelectedRows[0].Cells["nome"].Value.ToString();
                txtfuncao.Text = dtgfuncionario.SelectedRows[0].Cells["funcao"].Value.ToString();
                txtsalario.Text = dtgfuncionario.SelectedRows[0].Cells["salario"].Value.ToString();
            }
            if (txtnome.Text != string.Empty)
            {

                btncancelar.Enabled = true;
                btninserir.Enabled = false;

            }
        }

    }
       
  }
