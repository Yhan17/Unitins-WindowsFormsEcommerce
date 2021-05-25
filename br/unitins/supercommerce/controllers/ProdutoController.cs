using supermercadoEcommerce.br.unitins.supercommerce.dao;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.controllers
{
    class ProdutoController : Controller<Produto>
    {
        public override void Create(Produto param)
        {
            ProdutoDao dao = new ProdutoDao();
            dao.Create(param);
        }

        public override void Destroy(Produto param)
        {
            ProdutoDao dao = new ProdutoDao();
            dao.Destroy(param);
        }

        public override void Edit(Produto param)
        {
            ProdutoDao dao = new ProdutoDao();
            dao.Edit(param);
            MessageBox.Show("Elemento Editado com Sucesso");
        }

        public override List<Produto> Index()
        {
            ProdutoDao dao = new ProdutoDao();
            List<Produto> retorno = dao.Index();
            if (retorno != null)
            {
                return retorno;
            }

            return null;
        }

        public override Produto Show(int id)
        {
            ProdutoDao dao = new ProdutoDao();
            Produto cat = dao.Show(id);
            return cat;
        }
    }
}
