using supermercadoEcommerce.br.unitins.supercommerce.application;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.controllers
{
    abstract class Controller<T> : Crud<T>
    {
        public abstract void Create(T param);

        public abstract void Destroy(T param);

        public abstract void Edit(T param);

        public abstract List<T> Index();

        public abstract T Show(int id);
    }
}
