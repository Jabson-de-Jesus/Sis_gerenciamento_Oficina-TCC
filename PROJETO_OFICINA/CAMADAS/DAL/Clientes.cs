using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Clientes
    {
        public string strCon = conexao.getconexao();

        public List<MODEL.Clientes> Select()
        {
            List<MODEL.Clientes> lstCliente = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Clientes";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.id = Convert.ToInt32(reader[0].ToString());
                    cliente.nome = reader["nome"].ToString();
                    cliente.endereco = reader["endereco"].ToString();
                    cliente.cidade = reader["cidade"].ToString();
                    cliente.estado = reader["estado"].ToString();
                    cliente.telefone = reader["telefone"].ToString();
                    lstCliente.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }

            return lstCliente;

        }

        public void Insert(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Clientes values (@nome, @endereco, @cidade, @estado, @telefone);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@estado", cliente.estado);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Clientes set nome=@nome, ";
            sql += " endereco=@endereco, cidade=@cidade, ";
            sql += " estado=@estado, telefone=@telefone where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@estado", cliente.estado);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Clientes");
            }
            finally
            {
                conexao.Close();
            }



        }

        public void Updatetest(MODEL.Clientes cliente)
        {
            SqlConnection sql = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand("update Clientes set nome=@nome, endereco=@endereco, cidade=@cidade, estado=@estado, telefone=@telefone where id=@id;", sql);
            command.Parameters.AddWithValue("@id", cliente.id);
            command.Parameters.AddWithValue("@nome", cliente.nome);
            command.Parameters.AddWithValue("@endereco", cliente.endereco);
            command.Parameters.AddWithValue("@cidade", cliente.cidade);
            command.Parameters.AddWithValue("@estado", cliente.estado);
            command.Parameters.AddWithValue("@telefone", cliente.telefone);
            sql.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Clientes");
            }
            finally
            {
                sql.Close();
            }
        }

        public void updatetest2(MODEL.Clientes cliente)
        {
            try
            {
                SqlConnection sqlconexao = new SqlConnection(strCon);
                SqlCommand sqlcomando = new SqlCommand("Update Clientes set nome=@nome, endereco=@endereco, cidade=@cidade,  estado=@estado, telefone=@telefone where id=@id;", sqlconexao);
                sqlcomando.Parameters.AddWithValue("@id", cliente.id);
                sqlcomando.Parameters.AddWithValue("@nome", cliente.nome);
                sqlcomando.Parameters.AddWithValue("@endereco", cliente.endereco);
                sqlcomando.Parameters.AddWithValue("@cidade", cliente.cidade);
                sqlcomando.Parameters.AddWithValue("@estado", cliente.estado);
                sqlcomando.Parameters.AddWithValue("@telefone", cliente.telefone);
                sqlconexao.Open();
                sqlcomando.ExecuteNonQuery();
            }
            catch
            {

                Console.WriteLine("Erro na atualização de Clientes");
            }
            finally
            {



            }



        }

        public void Delete(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Clientes where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Clientes");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Deletetest(MODEL.Clientes cliente)
        {

            try
            {
                SqlConnection sqlconexao = new SqlConnection(strCon);
                SqlCommand sqlcomando = new SqlCommand("Delete from Clientes where id=@id; ", sqlconexao);
                sqlcomando.Parameters.AddWithValue("@id", cliente.id);
                sqlconexao.Open();
                sqlcomando.ExecuteNonQuery();

            }
            catch (Exception erro)
            {

                throw erro;
                
            }
           

        }



    }
}
    

