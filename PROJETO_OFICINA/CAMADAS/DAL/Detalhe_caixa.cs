using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Detalhe_caixa
    {
        string strCon = conexao.getconexao();

        public List<MODEL.Detalhe_caixa> Select()
        {
            List<MODEL.Detalhe_caixa> listcaixa = new List<MODEL.Detalhe_caixa>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Detalhe_caixa";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Detalhe_caixa caixa = new MODEL.Detalhe_caixa();
                    caixa.id = Convert.ToInt32(reader[0].ToString());
                    caixa.idcaixa = Convert.ToInt32(reader["idcaixa"].ToString());
                    caixa.data = Convert.ToDateTime(reader["data"].ToString());
                    caixa.valor_entrada = Convert.ToInt32(reader["valor_entrada"].ToString());
                    caixa.valor_saida = Convert.ToInt32(reader["valor_saida"].ToString());
                    
                    listcaixa.Add(caixa);
                  
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

            return listcaixa;

        }

        public void Insert(MODEL.Detalhe_caixa dtlcaixa)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Detalhe_caixa values (@idcaixa, @data, @valor_entrada, @valor_saida, @observacao);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idcaixa", dtlcaixa.idcaixa);
            cmd.Parameters.AddWithValue("@data", dtlcaixa.data);
            cmd.Parameters.AddWithValue("@valor_entrada", dtlcaixa.valor_entrada);
            cmd.Parameters.AddWithValue("@valor_saida" , dtlcaixa.valor_saida);
            cmd.Parameters.AddWithValue("@observacao", dtlcaixa.observacao);
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

        public void Update(MODEL.Detalhe_caixa dtlcaixa)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Detalhe_caixa set idcaixa=@idcaixa, ";
            sql += " data=@data, valor_entrada=@valor_entrada, valor_saida=@valor_saida, ";
            sql += " observacao=@observacao where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idcaixa", dtlcaixa.idcaixa);
            cmd.Parameters.AddWithValue("@data", dtlcaixa.data);
            cmd.Parameters.AddWithValue("@valor_entrada", dtlcaixa.valor_entrada);
            cmd.Parameters.AddWithValue("@valor_saida",  dtlcaixa.valor_saida);
            cmd.Parameters.AddWithValue("@observacao", dtlcaixa.observacao);
            
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Detalhe_caixa dtlcaixa)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Detalhe_caixa where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", dtlcaixa.id);
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
