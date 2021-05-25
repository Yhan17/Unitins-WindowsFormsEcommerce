using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using supermercadoEcommerce.br.unitins.supercommerce.application;
using supermercadoEcommerce.br.unitins.supercommerce.models;

namespace supermercadoEcommerce.br.unitins.supercommerce.dao
{
    class VendaDao : Dao<Venda>
    {
        public override void Create(Venda param)
        {
            SqlCommand vendaCommand = new SqlCommand("insert into vendas(quantidade,total,usuario_id) values(@tbQuantidade,@tbTotal,@tbUsuarioId); SELECT SCOPE_IDENTITY()", Con);
            vendaCommand.Parameters.Add("@tbQuantidade", SqlDbType.Int).Value = param.Quantidade;
            vendaCommand.Parameters.Add("@tbTotal", SqlDbType.Int).Value = param.Total;
            vendaCommand.Parameters.Add("@tbUsuarioId", SqlDbType.Int).Value = param.Usuario.ID;
           

            Con = Connect();
            SqlTransaction tran = Con.BeginTransaction();
            try
            {
                vendaCommand.Transaction = tran;
                var id = Convert.ToInt32(vendaCommand.ExecuteScalar());
                foreach(ItemVenda item in param.ListaItemVendidos)
                {
                    bool retorno = AddItemVenda(id, item, tran);
                }
               
                tran.Commit();
                MessageBox.Show("Enviado Com Sucesso");
            }
            catch (SqlException ex)
            {
                tran.Rollback();

                MessageBox.Show("Erro: " + ex.Message);

            }
            finally
            {
                Con = Disconnect();
            }
        }

        private bool AddItemVenda(int VendaId,ItemVenda item, SqlTransaction tran)
        {
            bool retorno = false;

            SqlCommand itemVendaCommand = new SqlCommand("insert into item_venda(venda_id,produto_id,valor_item_total,quantidade) values(@venda,@produto,@valor,@quantidade)", Con);
            itemVendaCommand.Parameters.Add("@venda", SqlDbType.Int).Value = VendaId;
            itemVendaCommand.Parameters.Add("@produto", SqlDbType.Int).Value = item.Produto.ID;
            itemVendaCommand.Parameters.Add("@valor", SqlDbType.Float).Value = item.ValorItemTotal;
            itemVendaCommand.Parameters.Add("@quantidade", SqlDbType.Int).Value = item.Quantidade;

            itemVendaCommand.Transaction = tran;

            try
            {
                itemVendaCommand.ExecuteNonQuery();
                retorno = true;
            }
            catch (SqlException ex)
            {
                throw ex;
                retorno = false;
            }
            return retorno;
        }

        public override void Destroy(Venda param)
        {
            throw new NotImplementedException();
        }

        public override void Edit(Venda param)
        {
            throw new NotImplementedException();
        }

        public override List<Venda> Index()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Venda> exist = new List<Venda>();

            cmd.CommandText = "select vendas.*,usuarios.nome from vendas,usuarios  Where vendas.usuario_id = usuarios.id order by vendas.id";

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Venda aux = new Venda();
                        aux.Usuario = new Usuario();
                        aux.ID = Convert.ToInt32(dr["id"].ToString());
                        aux.Total = Convert.ToSingle(dr["total"].ToString());
                        aux.Quantidade = Convert.ToInt32(dr["quantidade"].ToString());
                        aux.Usuario.Nome = dr["nome"].ToString();
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
        
        public List<Venda> MyIndex()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Venda> exist = new List<Venda>();

            cmd.CommandText = "select vendas.*,usuarios.nome from vendas,usuarios  where vendas.usuario_id = @usuario AND vendas.usuario_id = usuarios.id order by vendas.id";
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = Globals.Usu.ID;

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Venda aux = new Venda();
                        aux.Usuario = new Usuario();
                        aux.ID = Convert.ToInt32(dr["id"].ToString());
                        aux.Total = Convert.ToSingle(dr["total"].ToString());
                        aux.Quantidade = Convert.ToInt32(dr["quantidade"].ToString());
                        aux.Usuario.Nome = dr["nome"].ToString();
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

        public override Venda Show(int id)
        {
            throw new NotImplementedException();
        }
    }
}
