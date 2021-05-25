using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    public class Produto : Entity<Produto>
    {
        private string _nome;
        private String _descricao;
        private int _estoque;
        private float _preco;
        private Categoria _categoria;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string Descricao
        {
            get => _descricao;
            set => _descricao = value;
        }
        public int Estoque
        {
            get => _estoque;
            set => _estoque = value;
        }

        public float Preco
        {
            get => _preco;
            set => _preco = value;
        }

        public Categoria Categoria
        {
            get => _categoria;
            set => _categoria = value;
        }

    }
}
