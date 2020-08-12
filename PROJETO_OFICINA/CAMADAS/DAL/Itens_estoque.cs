using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{

    public class Itens_estoque
    {
        string strCon = conexao.getconexao();

        public List<MODEL.Itens_estoque> Select()
        {
            List<MODEL.Itens_estoque> lstintens = new List<MODEL.Itens_estoque>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Itens_estoque";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Itens_estoque itens = new MODEL.Itens_estoque();
                    itens.id = Convert.ToInt32(reader[0].ToString());
                    itens.idestoque = Convert.ToInt32(reader["idestoque"].ToString());
                    itens.idmaterial=Convert.ToInt32(reader["idmaterial"].ToString());
                    itens.nome_material = reader["nome_material"].ToString();
                    itens.quantidade = Convert.ToInt32(reader["quantidade"].ToString());
                    itens.valor = Convert.ToSingle(reader["valor"].ToString());
                    lstintens.Add(itens);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção ...");
            }
            finally
            {
                conexao.Close();
            }

            return lstintens;

        }

        public void Insert(MODEL.Itens_estoque itens)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Itens_estoque values (@idestoque, @idmaterial, @nome_material, @quantidade, @valor);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idestoque", itens.idestoque);
            cmd.Parameters.AddWithValue("@idmaterial", itens.idmaterial);
            cmd.Parameters.AddWithValue("@nome_material", itens.nome_material);
            cmd.Parameters.AddWithValue("@quantidade", itens.quantidade);
            cmd.Parameters.AddWithValue("@valor", itens.valor);
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

        public void Update(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Clientes set nome=@nome, ";
            sql += " endereco=@endereco, cidade=@cidade, ";
            sql += " estado=@estado, telefone=@telefone ";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@estado", cliente.estado);
            cmd.Parameters.AddWithValue("@aniversario", cliente.telefone);
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

    }
}
