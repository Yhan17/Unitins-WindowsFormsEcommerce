using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.application
{
    interface Crud<T>
    {
        void Create(T param);
        void Edit(T param);
        void Destroy(T param);
        List<T> Index();
        T Show(int id);
    }
}
