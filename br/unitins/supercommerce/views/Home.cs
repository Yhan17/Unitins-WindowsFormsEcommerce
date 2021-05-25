using supermercadoEcommerce.br.unitins.supercommerce.application;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product productScreen = new Product();
            productScreen.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category categoryScreen = new Category();
            categoryScreen.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            UsuarioController controller = new UsuarioController();
            lbValorTotal.Text = controller.TotalDoUsuarioLogado().ToString();
            lbQuantidadeVenda.Text = controller.TotalDeItemsAdquiridos().ToString();
            lbUsuario.Text = Globals.Usu.Nome;
            comprarToolStripMenuItem.Visible = Globals.Usu.TipoUsuario == (TipoUsuario)1;
            cadastrosToolStripMenuItem.Visible = Globals.Usu.TipoUsuario == (TipoUsuario)1;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users userScreen = new Users();
            userScreen.Show();
        }

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart carrinhoScreen = new Cart();
            carrinhoScreen.Show();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profileScreen = new Profile();
            profileScreen.Show();
            this.Hide();
        }

        private void produtosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Main mainScreen = new Main();
            this.Hide();
            mainScreen.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void carrinhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart carrinhoScreen = new Cart();
            carrinhoScreen.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainScreen = new Main();
            mainScreen.Show();
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
