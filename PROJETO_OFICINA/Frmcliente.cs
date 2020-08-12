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
    public partial class Frmcliente : Form
    {

    
        public Frmcliente()
        {
            InitializeComponent();
        }

        private char OP = 'V';


        private void Frmcliente_Load(object sender, EventArgs e)
        {
            CAMADAS.DAL.Clientes dalcli = new CAMADAS.DAL.Clientes();
            dtgcliente.DataSource = dalcli.Select();
            habilitacampos(false);

        }

        private void habilitacampos(bool status)
        {
            btninserir.Enabled = !status;
            btncadastrar.Enabled = status;
            btneditar.Enabled = !status;
            btnexcluir.Enabled = !status;
            btncancelar.Enabled = status;
            dtgcliente.Enabled = !status;



            Txtid.Enabled = false;
            txtnome.Enabled = status;
            Txtendereco.Enabled = status;
            Txtcidade.Enabled = status;
            Txtestado.Enabled = status;
            txttelefone.Enabled = status;



        }
        private void Btncadastrar_Click(object sender, EventArgs e)
        {


            CAMADAS.MODEL.Clientes cli = new CAMADAS.MODEL.Clientes();
            CAMADAS.DAL.Clientes dalclie = new CAMADAS.DAL.Clientes();

            cli.id = Convert.ToInt32(Txtid.Text);
            cli.nome = txtnome.Text;
            cli.endereco = Txtendereco.Text;
            cli.cidade = Txtcidade.Text;
            cli.estado = Txtestado.Text;
            cli.telefone = txttelefone.Text;

         


            if (txtnome.Text == string.Empty && Txtcidade.Text == string.Empty && txttelefone.Text == string.Empty)
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
                        dalclie.Insert(cli);
                    else
                    {
                       
                        dalclie.Update(cli);
                    }
                }

                dtgcliente.DataSource = dalclie.Select();

                OP = 'V';
                habilitacampos(false);


                Txtid.Text = "00";
                txtnome.Text = "";
                Txtendereco.Text = "";
                Txtcidade.Text = "";
                Txtestado.Text = "";
                txttelefone.Text = "";
                habilitacampos(false);

            }
        }


        private void Btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Txtid.Text) > 0)
            {
                OP = 'E';
                habilitacampos(true);
               

            }
            else
            {
                MessageBox.Show("Não há registros Selecionado");
            }
            
        }

        private void Btninserir_Click(object sender, EventArgs e)
        {
            OP = 'I';
            habilitacampos(true);
            

        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Txtid.Text) > 0)
            {
                CAMADAS.MODEL.Clientes cliente = new CAMADAS.MODEL.Clientes();
                CAMADAS.DAL.Clientes dalcli = new CAMADAS.DAL.Clientes();

                cliente.id = Convert.ToInt32(Txtid.Text);
                DialogResult result;
                result = MessageBox.Show("Deseja Remover o cliente Selecionado?",
                                          "Remover Cliente",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dalcli.Deletetest(cliente);
                    MessageBox.Show("Cliente Removido com Sucesso...");
                }
                else MessageBox.Show("Não confirmada Remoção de Cliente...", "Remover");


                dtgcliente.DataSource = dalcli.Select(); //atualizar lista de registro
                habilitacampos(false);
            }
            else MessageBox.Show("Não há registro Selecionado", "Remover");


                    Txtid.Text = "00";
                    txtnome.Text = "";
                    Txtendereco.Text = "";
                    Txtcidade.Text = "";
                    Txtestado.Text = "";
                    txttelefone.Text = "";
                    OP = 'V';
                    habilitacampos(false);

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            
                Txtid.Text = "00";
                txtnome.Text = "";
                Txtendereco.Text = "";
                Txtcidade.Text = "";
                Txtestado.Text = "";
                txttelefone.Text = "";
                OP = 'V';
                habilitacampos(false);
           
        }

        private void dtgcliente_DoubleClick(object sender, EventArgs e)
        {
            if (dtgcliente.SelectedRows.Count > 0)
            {
                Txtid.Text = dtgcliente.SelectedRows[0].Cells["id"].Value.ToString();
                txtnome.Text = dtgcliente.SelectedRows[0].Cells["nome"].Value.ToString();
                Txtendereco.Text = dtgcliente.SelectedRows[0].Cells["endereco"].Value.ToString();
                Txtcidade.Text = dtgcliente.SelectedRows[0].Cells["cidade"].Value.ToString();
                Txtestado.Text = dtgcliente.SelectedRows[0].Cells["estado"].Value.ToString();
                txttelefone.Text = dtgcliente.SelectedRows[0].Cells["telefone"].Value.ToString();
            }
            if (txtnome.Text != string.Empty) {

                btncancelar.Enabled = true;
                btninserir.Enabled = false;

            }
         }

       
    }
}