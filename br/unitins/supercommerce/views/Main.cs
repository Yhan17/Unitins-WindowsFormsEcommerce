using supermercadoEcommerce.br.unitins.supercommerce.application;
using supermercadoEcommerce.br.unitins.supercommerce.controllers;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void PopulateFl()
        {
            ProdutoController controller = new ProdutoController();

            var databaseList = controller.Index();
            foreach (Produto prod in databaseList)
            {
                ProductList aux = new ProductList(this);
                aux.ProductName = prod.Nome;
                aux.Quantidade = prod.Estoque;
                aux.Valor = prod.Preco;
                aux.Produto = prod;
                flProduto.Controls.Add(aux);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LbQuantidade = Globals.CarrinhoSession.Count().ToString();
            PopulateFl();
            homeToolStripMenuItem.Visible = Globals.Usu != null;
            vendasToolStripMenuItem.Visible = Globals.Usu != null;
            perfilToolStripMenuItem.Visible = Globals.Usu != null;
            loginToolStripMenuItem.Visible = Globals.Usu == null;
            comprarToolStripMenuItem.Visible = (Globals.Usu != null && Globals.Usu.TipoUsuario == (TipoUsuario)1);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public string LbQuantidade
        {
            get { return lbQuantidadeItems.Text; }
            set { lbQuantidadeItems.Text = value; }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginScreen = new Login();
            this.Hide();
            loginScreen.Show();
        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart carrinhoScreen = new Cart();
            carrinhoScreen.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home homeScreen = new Home();
            homeScreen.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category categoryScreen = new Category();
            categoryScreen.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product productScreen = new Product();
            productScreen.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users userScreen = new Users();
            userScreen.Show();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profileScreen = new Profile();
            profileScreen.Show();
            this.Hide();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sells sellsScreen = new Sells();
            sellsScreen.Show();
        }

        private void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySells mySellsScreen = new MySells();
            mySellsScreen.Show();
        }
    }
}
