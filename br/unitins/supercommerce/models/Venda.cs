using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    class Venda : Entity<Venda>
    {
        private Usuario _usuario;
        private List<ItemVenda> _listaItemVendidos;
        private float _total;
        private int _quantidade;

        public Usuario Usuario
        {
            get => _usuario;
            set => _usuario = value;
        }     
        public List<ItemVenda> ListaItemVendidos
        {
            get => _listaItemVendidos;
            set => _listaItemVendidos = value;
        }    
        public float Total
        {
            get => _total;
            set => _total = value;
        }  
        public int Quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }


    }
}
