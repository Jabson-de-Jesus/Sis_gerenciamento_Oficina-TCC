using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Automoveis
    {
        string strCon = conexao.getconexao();

        public List<MODEL.Automoveis> Select()
        {
            List<MODEL.Automoveis> listmovel = new List<MODEL.Automoveis>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Automoveis";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Automoveis auto = new MODEL.Automoveis();
                    auto.id = Convert.ToInt32(reader[0].ToString());
                    auto.nome = reader["nome"].ToString();
                    auto.marca = reader["marca"].ToString();
                    auto.cor = reader["cor"].ToString();
                    auto.placa = reader["placa"].ToString();
                    listmovel.Add(auto);
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

            return listmovel;

        }

        public void Insert(MODEL.Automoveis automovel)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Automoveis values (@nome, @marca, @cor, @placa);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", automovel.nome);
            cmd.Parameters.AddWithValue("@marca", automovel.marca);
            cmd.Parameters.AddWithValue("@cor", automovel.cor);
            cmd.Parameters.AddWithValue("@placa", automovel.placa);
           
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção do Automovel...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Automoveis automovel)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Automoveis set nome=@nome, ";
            sql += " marca=@marca, cor=@cor, ";
            sql += " placa=@placa ";
            sql += " where id=@id; ";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", automovel.id );
            cmd.Parameters.AddWithValue("@nome", automovel.nome);
            cmd.Parameters.AddWithValue("@marca", automovel.marca);
            cmd.Parameters.AddWithValue("@cor", automovel.cor);
            cmd.Parameters.AddWithValue("@placa", automovel.placa);
          
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

        public void Delete(MODEL.Automoveis automovel)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Automoveis where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", automovel.id);
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

    }
}
