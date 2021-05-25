using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using supermercadoEcommerce.br.unitins.supercommerce.models;

namespace supermercadoEcommerce.br.unitins.supercommerce.dao
{
    class CategoriaDao : Dao<Categoria>
    {
        public override void Create(Categoria param)
        {
            SqlCommand categoryCommand = new SqlCommand("insert into categorias(nome,descricao) values(@nome,@descricao)", Con);
            categoryCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = param.Nome;
            categoryCommand.Parameters.Add("@descricao", SqlDbType.VarChar).Value = param.Descricao;

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

        public override void Destroy(Categoria param)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "delete categorias where id = @id";
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

        public override void Edit(Categoria param)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "update categorias set nome=@name,descricao=@descricao where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = param.ID;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = param.Nome;
            cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = param.Descricao;

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

        public override List<Categoria> Index()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Categoria> exist = new List<Categoria>();

            cmd.CommandText = "select * from categorias order by id";

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Categoria aux = new Categoria();
                        aux.ID = Convert.ToInt32(dr["id"].ToString());
                        aux.Nome = dr["nome"].ToString();
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

        public override Categoria Show(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Categoria exist = new Categoria();

            cmd.CommandText = "select * from categorias where id = @id";
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

                        exist.ID = Convert.ToInt32(dr["id"].ToString());
                        exist.Nome = dr["nome"].ToString();
                        exist.Descricao = dr["descricao"].ToString();
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
