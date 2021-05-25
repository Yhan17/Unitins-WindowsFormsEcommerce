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
    class CategoriaController : Controller<Categoria>
    {
        public override void Create(Categoria param)
        {
            CategoriaDao dao = new CategoriaDao();
            dao.Create(param);
        }

        public override void Destroy(Categoria param)
        {
            CategoriaDao dao = new CategoriaDao();
            dao.Destroy(param);

        }

        public override void Edit(Categoria param)
        {
            CategoriaDao dao = new CategoriaDao();
            dao.Edit(param);
            MessageBox.Show("Elemento Editado com Sucesso");

        }

        public override List<Categoria> Index()
        {
            CategoriaDao dao = new CategoriaDao();
            List<Categoria> retorno = dao.Index();
            if (retorno != null)
            {
                return retorno;
            }

            return null;
        }

        public override Categoria Show(int id)
        {
            CategoriaDao dao = new CategoriaDao();
            Categoria cat = dao.Show(id);
            return cat;
        }
    }
}
