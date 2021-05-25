using supermercadoEcommerce.br.unitins.supercommerce.application;
using supermercadoEcommerce.br.unitins.supercommerce.dao;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.controllers
{
    class LoginController : Controller<Usuario>
    {
        public bool Login(String login, String senha)
        {
            bool retorno = false;
            UsuarioDao dao = new UsuarioDao();
            Usuario usuario = dao.VerifyLogin(login, Utils.ComputeSha256Hash(senha));
            if(usuario != null)
            {
                //Globals.Usuario.Nome = usuario.Nome;
                Globals.Usu = usuario;
                retorno = true;
            }

            return retorno;
        }

        public override void Create(Usuario param)
        {
            throw new NotImplementedException();
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
