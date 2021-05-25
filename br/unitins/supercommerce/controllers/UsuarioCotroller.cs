using supermercadoEcommerce.br.unitins.supercommerce.application;
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
    class UsuarioController : Controller<Usuario>
    {
        public override void Create(Usuario param)
        {

            UsuarioDao dao = new UsuarioDao();
            dao.Create(param);
        }

        public override void Destroy(Usuario param)
        {
            UsuarioDao dao = new UsuarioDao();
            dao.Destroy(param);
        }

        public override void Edit(Usuario param)
        {
            UsuarioDao dao = new UsuarioDao();
            dao.Edit(param);

        }

        public override List<Usuario> Index()
        {
            UsuarioDao dao = new UsuarioDao();
            List<Usuario> retorno = dao.Index();
            if (retorno != null)
            {
                return retorno;
            }

            return null;
        }

        public override Usuario Show(int id)
        {
            UsuarioDao dao = new UsuarioDao();
            Usuario usu = dao.Show(id);
            return usu;
        }

        public float TotalDoUsuarioLogado()
        {
            UsuarioDao dao = new UsuarioDao();
            Console.WriteLine(Globals.Usu.ID);
            return dao.TotalComprado(Globals.Usu.ID);
        }      
        public int TotalDeItemsAdquiridos()
        {
            UsuarioDao dao = new UsuarioDao();
            Console.WriteLine(Globals.Usu.ID);

            return dao.TotalDeItensAdquiridos(Globals.Usu.ID);
        }
    }
}
