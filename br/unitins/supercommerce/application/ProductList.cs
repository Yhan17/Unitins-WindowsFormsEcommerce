using supermercadoEcommerce.br.unitins.supercommerce.models;
using supermercadoEcommerce.br.unitins.supercommerce.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.application
{
    public partial class ProductList : UserControl
    {
        public ProductList()
        {
            InitializeComponent();
        }
        private Main mainForm = null;

        public ProductList(Form callingForm)
        {
            mainForm = callingForm as Main;
            InitializeComponent();
        }

        private int _numberOfClicks = 0;


        private string _productName;
        private int _quantidade;
        private float _valor;
        protected Produto _produto;
        [Category("Custom Props")]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; lbProductName.Text = value; }
        }

        [Category("Custom Props")]
        public Produto Produto
        {
            get { return _produto; }
            set { _produto = value; }
        }

        [Category("Custom Props")]
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; lbQuantity.Text = value.ToString(); }
        }


        [Category("Custom Props")]
        public float Valor
        {
            get { return _valor; }
            set { _valor = value; lbValue.Text = value.ToString(); }
        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            lbQuantity.Text = (Convert.ToInt32(lbQuantity.Text) - 1).ToString();
            Globals.CarrinhoSession.Add(Produto);
            this.mainForm.LbQuantidade = Globals.CarrinhoSession.Count().ToString();
            if (_numberOfClicks < Quantidade - 1)
            {
                _numberOfClicks += 1;

            }
            else
            {

                btnCarrinho.Enabled = false;
            }
        }

        private void lbProductName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductPage produtoPage = new ProductPage(_produto.ID);
            produtoPage.Show();
        }
    }
}
