using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Estoque
    {
        string strCon = conexao.getconexao();

        public List<MODEL.Estoque> Select()
        {
            List<MODEL.Estoque> lstestoque = new List<MODEL.Estoque>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Estoque";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Estoque estoque = new MODEL.Estoque();
                    estoque.id = Convert.ToInt32(reader[0].ToString());
                    estoque.idfuncionario =Convert.ToInt32(reader["idfuncionario"].ToString());
                    estoque.idautomovel =Convert.ToInt32(reader["idautomovel"].ToString());
                    estoque.data = Convert.ToDateTime(reader["data"].ToString());
                    estoque.relatorio = reader["relatorio"].ToString();
                    estoque.total = Convert.ToSingle(reader["total"].ToString());

                    lstestoque.Add(estoque);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Estoque...");
            }
            finally
            {
                conexao.Close();
            }

            return lstestoque;

        }

        public void Insert(MODEL.Estoque estoque)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Estoque values (@idfuncionario, @idautomovel, @data, @relatorio, @total);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idfuncionario", estoque.idfuncionario);
            cmd.Parameters.AddWithValue("@idautomovel", estoque.idautomovel);
            cmd.Parameters.AddWithValue("@data", estoque.data);
            cmd.Parameters.AddWithValue("@relatorio", estoque.relatorio);
            cmd.Parameters.AddWithValue("@total" , estoque.total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Estoque...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Estoque estoque)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Estoque set idfuncionario=@idfuncionario, ";
            sql += " idautomovel=@idautomovel, data=@data, ";
            sql += " relatorio=@relatorio, total=@total ";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", estoque.id);
            cmd.Parameters.AddWithValue("@idfuncionario" , estoque.idfuncionario);
            cmd.Parameters.AddWithValue("@idautomovel", estoque.idautomovel);
            cmd.Parameters.AddWithValue("@data", estoque.data);
            cmd.Parameters.AddWithValue("@relatorio", estoque.relatorio);
            cmd.Parameters.AddWithValue("@total" , estoque.total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Estoque");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Estoque estoque)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Estoque where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", estoque.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de estoque");
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
