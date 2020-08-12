using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Caixa
       {
        string strCon = conexao.getconexao();

        public List<MODEL.Caixa> Select()
        {
            List<MODEL.Caixa> lstcaixa = new List<MODEL.Caixa>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Caixa";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Caixa caixa = new MODEL.Caixa();
                    caixa.id = Convert.ToInt32(reader[0].ToString());
                    caixa.saldo_inicial = Convert.ToInt32(reader["saldo_inicial"].ToString());
                    caixa.saldo_final = Convert.ToInt32(reader["saldo_final"].ToString());
                    caixa.hora_inicial = Convert.ToDateTime(reader["hora_inicial"].ToString());
                    caixa.hora_final = Convert.ToDateTime(reader["hora_final"].ToString());
                    caixa.status = reader["status"].ToString();
                    lstcaixa.Add(caixa);
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

            return lstcaixa;

        }

        public void Insert(MODEL.Caixa caixa)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Caixa values (@saldo_inicial, @saldo_final, @hora_inicial, @hora_final, @status);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@saldo_inicial", caixa.saldo_inicial);
            cmd.Parameters.AddWithValue("@saldo_final", caixa.saldo_final);
            cmd.Parameters.AddWithValue("@hora_inicial", caixa.hora_inicial);
            cmd.Parameters.AddWithValue("@hora_final", caixa.hora_final);
            cmd.Parameters.AddWithValue("@status", caixa.status);
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

        public void Update(MODEL.Caixa caixa)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Caixa set saldo_inicial=@saldo_inicial, ";
            sql += " saldo_final=@saldo_final, hora_inicial=@hora_inicial, ";
            sql += " hora_final=@hora_final, status=@status ";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", caixa.id);
            cmd.Parameters.AddWithValue("@saldo_inicial", caixa.saldo_inicial);
            cmd.Parameters.AddWithValue("@saldo_final", caixa.saldo_final);
            cmd.Parameters.AddWithValue("@hora_inicial", caixa.hora_inicial );
            cmd.Parameters.AddWithValue("@hora_final",caixa.hora_final );
            cmd.Parameters.AddWithValue("@status", caixa.status);
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

        public void Delete(MODEL.Caixa caixa)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Caixa where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", caixa.id);
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
