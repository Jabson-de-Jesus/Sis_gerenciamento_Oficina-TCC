using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Funcionarios 
    {
        string strCon = conexao.getconexao();

        public List<MODEL.Funcionarios> Select()
        {
            List<MODEL.Funcionarios> lstfunci = new List<MODEL.Funcionarios>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Funcionarios";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Funcionarios funcionario = new MODEL.Funcionarios();
                    funcionario.id = Convert.ToInt32(reader[0].ToString());
                    funcionario.nome = reader["nome"].ToString();
                    funcionario.funcao = reader["funcao"].ToString();
                    funcionario.salario = Convert.ToInt32(reader["salario"].ToString());
                    lstfunci.Add(funcionario);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção do Funcionario...");
            }
            finally
            {
                conexao.Close();
            }

            return lstfunci;

        }

        public void Insert(MODEL.Funcionarios funcionario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Funcionarios values (@nome, @funcao, @salario);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@funcao", funcionario.funcao);
            cmd.Parameters.AddWithValue("@salario", funcionario.salario);
            
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção do Funcionario...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Funcionarios funcionario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Funcionarios set nome=@nome, ";
            sql += " funcao=@funcao, salario=@salario ";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", funcionario.id);
            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@funcao", funcionario.funcao);
            cmd.Parameters.AddWithValue("salario", funcionario.salario);
   
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização do Funcionário");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Funcionarios funcionario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Funcionarios where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", funcionario.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção do Funcionario");
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
