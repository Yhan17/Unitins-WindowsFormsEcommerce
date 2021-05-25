using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    public class Categoria : Entity<Categoria>
    {
        private string _nome;
        private String _descricao;

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
    }
}
