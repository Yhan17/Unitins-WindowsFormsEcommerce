using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    class Usuario : Entity<Usuario>
    {
        private string _nome;
        private string _email;
        private string _cpf;
        private String _senha;
        private TipoUsuario _tipoUsuario;
        private Endereco _endereco;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }
        public string Cpf
        {
            get => _cpf;
            set => _cpf = value;
        }
        public String Senha
        {
            get => _senha;
            set => _senha = value;
        }
        public TipoUsuario TipoUsuario
        {
            get => _tipoUsuario;
            set => _tipoUsuario = value;
        }
        public Endereco Endereco
        {
            get => _endereco;
            set => _endereco = value;
        }
    }
}
