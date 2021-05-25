using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    class Endereco : Entity<Endereco>
    {
        private string _cep;
        private string _enderecoCompleto;
        private string _complemento;
        private string _bairro;
        private string _cidade;
        private string _uf;

        public string Cep
        {
            get => _cep;
            set => _cep = value;
        }
        public string EnderecoCompleto
        {
            get => _enderecoCompleto;
            set => _enderecoCompleto = value;
        }
        public string Complemento
        {
            get => _complemento;
            set => _complemento = value;
        }
        public string Bairro
        {
            get => _bairro;
            set => _bairro = value;
        }
        public string Cidade
        {
            get => _cidade;
            set => _cidade = value;
        }
        public string Uf
        {
            get => _uf;
            set => _uf = value;
        }

    }
}
