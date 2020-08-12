using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{
    public class Servicos
    {

        private string strCon = conexao.getconexao();

        public List<MODEL.Servicos> Select()
        {
            List<MODEL.Servicos> lstservico = new List<MODEL.Servicos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * From Servicos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    MODEL.Servicos servico = new MODEL.Servicos();
                    servico.id = Convert.ToInt32(reader[0].ToString());
                    servico.nome = reader["nome"].ToString();
                    servico.valor_unit = Convert.ToInt32(reader["valor_unit"].ToString());
                    servico.observacao = reader["observacao"].ToString();
                    lstservico.Add(servico);

                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Serviços...");

            }
            finally
            {

                conexao.Close();
            }

            return lstservico;

        }


        public void Insert(MODEL.Servicos servicos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Servicos values (@nome, @valor_unit, @observacao);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", servicos.nome);
            cmd.Parameters.AddWithValue("@valor_unit", servicos.valor_unit);
            cmd.Parameters.AddWithValue("@observacao", servicos.observacao);

            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Serviços...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Servicos servicos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Servicos where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", servicos.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Serviços");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(MODEL.Servicos servicos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Servicos set nome=@nome, ";
            sql += " valor_unit=valor_unit,";
            sql += "observacao=@observacao where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", servicos.id);
            cmd.Parameters.AddWithValue("@nome", servicos.nome);
            cmd.Parameters.AddWithValue("@valor_unit", servicos.valor_unit);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Serviços");
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
