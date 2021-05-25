using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    class ItemVenda: Entity<ItemVenda>
    {
        private Venda _venda;
        private Produto _produto;
        private float _valorItemTotal;
        private int _quantidade;

        public Venda Venda
        {
            get => _venda;
            set => _venda = value;
        }
        public Produto Produto
        {
            get => _produto;
            set => _produto = value;
        } 
        public float ValorItemTotal
        {
            get => _valorItemTotal;
            set => _valorItemTotal = value;
        }        
        public int Quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }
    }
}
