using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{
    public class Material
    {
        string strCon = conexao.getconexao();

        public List<MODEL.Materiais> Select()
        {
            List<MODEL.Materiais> lstmaterial = new List<MODEL.Materiais>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Materiais";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Materiais material = new MODEL.Materiais();
                    material.id = Convert.ToInt32(reader[0].ToString());
                    material.nome = reader["nome"].ToString();
                    material.quantidade =Convert.ToInt32(reader["quantidade"].ToString());
                    material.peso = reader["peso"].ToString();
                    material.valor = Convert.ToSingle(reader["valor"].ToString());
                    material.observacao = reader["observacao"].ToString();
                    lstmaterial.Add(material);
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

            return lstmaterial;

        }

        public void Insert(MODEL.Materiais material)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Materiais values (@nome, @quantidade, @peso, @valor, @observacao);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", material.nome);
            cmd.Parameters.AddWithValue("@quantidade",material.quantidade);
            cmd.Parameters.AddWithValue("@peso", material.peso);
            cmd.Parameters.AddWithValue("@valor", material.valor);
            cmd.Parameters.AddWithValue("@observacao", material.observacao);
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

        public void Update(MODEL.Materiais material)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Materiais set nome=@nome, ";
            sql += " quantidade=@quantidade, peso=@peso, ";
            sql += " valor=@valor, observacao=@observacao";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", material.id);
            cmd.Parameters.AddWithValue("@nome", material.nome);
            cmd.Parameters.AddWithValue("@quantidade", material.quantidade);
            cmd.Parameters.AddWithValue("@peso", material.peso);
            cmd.Parameters.AddWithValue("@valor", material.valor);
            cmd.Parameters.AddWithValue("@observacao", material.observacao );
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

        public void Delete(MODEL.Materiais material)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Materiais where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", material.id);
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
