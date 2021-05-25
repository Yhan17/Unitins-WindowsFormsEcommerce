using supermercadoEcommerce.br.unitins.supercommerce.controllers;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    public partial class ProductPage : Form
    {
        private static Produto product = new Produto();
        public ProductPage(int id)
        {
            ProdutoController controller = new ProdutoController();
            product = controller.Show(id);
            Console.WriteLine(product.Nome);

            InitializeComponent();
            lbProuctName.Text = product.Nome;
            lbPreco.Text = product.Preco.ToString();
            lbQuantidade.Text = product.Estoque.ToString();
            lbCategoria.Text = product.Categoria.Nome;
            lbDescricao.Text = product.Descricao;

        }
    }
}
