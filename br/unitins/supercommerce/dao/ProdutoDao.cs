using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.dao
{
    class ProdutoDao : Dao<Produto>
    {
        public override void Create(Produto param)
        {
            SqlCommand categoryCommand = new SqlCommand("insert into produtos(nome,descricao,estoque,preco,categoria_id) values(@nome,@descricao,@estoque,@preco,@categoria)", Con);
            categoryCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = param.Nome;
            categoryCommand.Parameters.Add("@descricao", SqlDbType.VarChar).Value = param.Descricao;
            categoryCommand.Parameters.Add("@estoque", SqlDbType.VarChar).Value = param.Estoque;
            categoryCommand.Parameters.Add("@preco", SqlDbType.VarChar).Value = param.Preco;
            categoryCommand.Parameters.Add("@categoria", SqlDbType.VarChar).Value = param.Categoria.ID;

            try
            {
                Con = Connect();

                categoryCommand.ExecuteNonQuery();
                MessageBox.Show("Enviado Com Sucesso");
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Erro: " + ex.Message);

            }
            finally
            {
                Con = Disconnect();
            }
        }

        public override void Destroy(Produto param)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "delete produtos where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = param.ID;

            try
            {
                Connect();
                cmd.Connection = Con;
                cmd.ExecuteReader();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public override void Edit(Produto param)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "update produtos set nome=@name,descricao=@descricao,estoque=@estoque,preco=@preco,categoria_id=@categoria where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = param.ID;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = param.Nome;
            cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = param.Descricao;
            cmd.Parameters.Add("@estoque", SqlDbType.VarChar).Value = param.Estoque;
            cmd.Parameters.Add("@preco", SqlDbType.VarChar).Value = param.Preco;
            cmd.Parameters.Add("@categoria", SqlDbType.VarChar).Value = param.Categoria.ID;

            try
            {
                Connect();
                cmd.Connection = Con;
                cmd.ExecuteReader();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public override List<Produto> Index()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Produto> exist = new List<Produto>();

            cmd.CommandText = "select * from produtos order by id";

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Produto aux = new Produto();
                        aux.Categoria = new Categoria();
                        aux.ID = Convert.ToInt32(dr["id"].ToString());
                        aux.Nome = dr["nome"].ToString();
                        aux.Preco = Convert.ToSingle(dr["preco"].ToString());
                        aux.Estoque = Convert.ToInt32(dr["estoque"].ToString());
                        aux.Categoria.ID= Convert.ToInt32(dr["categoria_id"].ToString());
                        exist.Add(aux);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return exist;
        }

        public override Produto Show(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Produto exist = new Produto();
            exist.Categoria = new Categoria();

            cmd.CommandText = "select produtos.*,categorias.nome AS 'categoriaName' from produtos,categorias where produtos.id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        exist.Categoria = new Categoria();
                        exist.ID = Convert.ToInt32(dr["id"].ToString());
                        exist.Nome = dr["nome"].ToString();
                        exist.Preco = Convert.ToSingle(dr["preco"].ToString());
                        exist.Descricao = dr["descricao"].ToString();
                        exist.Estoque = Convert.ToInt32(dr["estoque"].ToString());
                        exist.Categoria.ID = Convert.ToInt32(dr["categoria_id"].ToString());
                        exist.Categoria.Nome = dr["categoriaName"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return exist;
        }
    }
}
