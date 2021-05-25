using supermercadoEcommerce.br.unitins.supercommerce.dao;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.controllers
{
    class RegisterController: Controller<Usuario>
    {
        public override void Create(Usuario usuario)
        {
            UsuarioDao dao = new UsuarioDao();
            dao.Create(usuario);
           
        }

        public override void Destroy(Usuario param)
        {
            throw new NotImplementedException();
        }

        public override void Edit(Usuario param)
        {
            throw new NotImplementedException();
        }

        public override List<Usuario> Index()
        {
            throw new NotImplementedException();
        }

        public override Usuario Show(int id)
        {
            throw new NotImplementedException();
        }
    }
}
