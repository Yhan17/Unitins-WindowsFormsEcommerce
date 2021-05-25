using supermercadoEcommerce.br.unitins.supercommerce.dao;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.controllers
{
    class VendaController : Controller<Venda>
    {
        public override void Create(Venda param)
        {
            VendaDao dao = new VendaDao();
            dao.Create(param);
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
            VendaDao dao = new VendaDao();
            List<Venda> retorno = dao.Index();
            if (retorno != null)
            {
                return retorno;
            }

            return null;
        }        
        public List<Venda> MyIndex()
        {
            VendaDao dao = new VendaDao();
            List<Venda> retorno = dao.MyIndex();
            if (retorno != null)
            {
                return retorno;
            }

            return null;
        }

        public override Venda Show(int id)
        {
            throw new NotImplementedException();
        }
    }
}
