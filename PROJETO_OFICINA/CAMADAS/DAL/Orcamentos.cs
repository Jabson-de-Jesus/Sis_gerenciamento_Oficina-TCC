using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PROJETO_OFICINA.CAMADAS.DAL
{
    public class Orcamentos
    {
        private string strcon = conexao.getconexao();

        public List<MODEL.Orcamentos> Select()
        {
            List<MODEL.Orcamentos> listaorcam = new List<MODEL.Orcamentos>();
            SqlConnection conexao = new SqlConnection(strcon);
            string sql = "Select * From Orcamentos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Orcamentos orcam = new MODEL.Orcamentos();
                    orcam.id = Convert.ToInt32(reader[0].ToString());
                    orcam.idcliente = Convert.ToInt32(reader["idcliente"].ToString());
                    orcam.automovel = reader["automovel"].ToString();
                    orcam.cor = reader["cor"].ToString();
                    orcam.placa = reader["placa"].ToString();
                    orcam.discriminacao = reader["discriminacao"].ToString();
                    orcam.total = Convert.ToInt32(reader["total"].ToString());
                    listaorcam.Add(orcam);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção...");

            }
            finally
            {
                conexao.Close();
            }

            return listaorcam;
        }


        public void Insert(MODEL.Orcamentos orcamentos)
        {
            SqlConnection conexao = new SqlConnection(strcon);
            string sql = "Insert into orcamentos values (@idcliente, @automovel, @cor, @placa, @total);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idcliente", orcamentos.idcliente);
            cmd.Parameters.AddWithValue("@automovel", orcamentos.automovel);
            cmd.Parameters.AddWithValue("@cor", orcamentos.cor);
            cmd.Parameters.AddWithValue("@placa", orcamentos.placa);
            cmd.Parameters.AddWithValue("@disminacao", orcamentos.total);
            cmd.Parameters.AddWithValue("@total", orcamentos.total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Orcamentos orcamentos)
        {
            SqlConnection conexao = new SqlConnection(strcon);
            string sql = "Update Orcamentos set idcliente=@idcliente, ";
            sql += " automovel=@automovel, cor=@cor, ";
            sql += " placa=@placa, discrimicao=@discriminacao,";
            sql += "total=@total where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", orcamentos.id);
            cmd.Parameters.AddWithValue("@idclciente", orcamentos.idcliente);
            cmd.Parameters.AddWithValue("@automovel", orcamentos.automovel);
            cmd.Parameters.AddWithValue("@cor", orcamentos.cor);
            cmd.Parameters.AddWithValue("@placa", orcamentos.placa);
            cmd.Parameters.AddWithValue("@discriminacao", orcamentos.discriminacao);
            cmd.Parameters.AddWithValue("@total", orcamentos.total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização ");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Orcamentos orcamentos)
        {
            SqlConnection conexao = new SqlConnection(strcon);
            string sql = "Delete from Orcamentos where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", orcamentos.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção...");
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}