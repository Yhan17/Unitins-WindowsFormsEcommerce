using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.application
{
    static class Globals
    {
        //public static String GetGlobalUserName() 
        //{
        //    return GlobalInformation.Default.nome;
        //}        
        //public static void SetGlobalUserName(String name) 
        //{
        //    GlobalInformation.Default.nome = name;
        //    GlobalInformation.Default.Save();
        //}
        private static Usuario _usu;
        public static Usuario Usu
        {
            get => _usu;
            set => _usu = value;
        }

        private static List<Produto> _carrinho = new List<Produto>();
        public static List<Produto> CarrinhoSession
        {
            get => _carrinho;
            set => _carrinho = value;
        }
    }
}
