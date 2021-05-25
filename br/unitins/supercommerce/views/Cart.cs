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
    public partial class Cart : Form
    {
        private List<Produto> lista = Globals.CarrinhoSession.Distinct().ToList();
        private double total = 0.0;
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            comprarToolStripMenuItem.Visible = (Globals.Usu != null && Globals.Usu.TipoUsuario == (TipoUsuario)1);
            cadastrosToolStripMenuItem.Visible = (Globals.Usu != null && Globals.Usu.TipoUsuario == (TipoUsuario)1);
            homeToolStripMenuItem.Visible = Globals.Usu != null;
            vendasToolStripMenuItem.Visible = Globals.Usu != null;
            perfilToolStripMenuItem.Visible = Globals.Usu != null;
            loginToolStripMenuItem.Visible = Globals.Usu == null;
            dtCarrinho.Rows.Clear();
            if(Globals.CarrinhoSession.Count == 0)
            {
                btnVenda.Enabled = false;

            }
            foreach (Produto p in lista)
            {
                var countOfSameObject = Globals.CarrinhoSession.Count(element => element.ID == p.ID);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dtCarrinho);
                newRow.Cells[0].Value = lista.IndexOf(p);
                newRow.Cells[1].Value = p.Nome;
                newRow.Cells[2].Value = p.Preco;
                newRow.Cells[3].Value = countOfSameObject;
                total += (countOfSameObject * p.Preco);
                dtCarrinho.Rows.Add(newRow);
            }
            lbTotal.Text = total.ToString();
        }

        private void dtCarrinho_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) btnRemove.Enabled = false;
            else btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dtCarrinho.SelectedRows[0].Cells[3].Value) > 1)
            {
                total -= Convert.ToDouble(dtCarrinho.SelectedRows[0].Cells[2].Value);
                dtCarrinho.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dtCarrinho.SelectedRows[0].Cells[3].Value) - 1;
                foreach (Produto p in Globals.CarrinhoSession)
                {
                    if (lista[Convert.ToInt32(dtCarrinho.SelectedRows[0].Cells[0].Value)].ID == p.ID)
                    {
                        Globals.CarrinhoSession.Remove(p);
                        break;
                    }
                }
            }
            else
            {
                total -= Convert.ToDouble(dtCarrinho.SelectedRows[0].Cells[2].Value);

                foreach (Produto p in Globals.CarrinhoSession)
                {
                    if (lista[Convert.ToInt32(dtCarrinho.SelectedRows[0].Cells[0].Value)].ID == p.ID)
                    {
                        Globals.CarrinhoSession.Remove(p);
                        break;
                    }
                }
                lista.RemoveAt(Convert.ToInt32(dtCarrinho.SelectedRows[0].Cells[0].Value));
                dtCarrinho.Rows.Remove(dtCarrinho.SelectedRows[0]);
                if(dtCarrinho.Rows.Count == 0)
                {
                    btnVenda.Enabled = false;
                }
            }
            lbTotal.Text = total.ToString();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            if (Globals.Usu == null)
            {
                this.Hide();
                Login loginScreen = new Login();
                loginScreen.Show();
            }
            else
            {
                float total = Globals.CarrinhoSession.Sum(x => x.Preco);
                Venda venda = new Venda();
                venda.ListaItemVendidos = new List<ItemVenda>();
                venda.Usuario = new Usuario();
                venda.Usuario = Globals.Usu;
                venda.Quantidade = Globals.CarrinhoSession.Count;
                venda.Total = total;
                foreach (Produto p in lista)
                {
                    var countOfSameSingleObject = Globals.CarrinhoSession.Count(element => element.ID == p.ID);
                    ItemVenda aux = new ItemVenda();
                    aux.Produto = p;
                    aux.Quantidade = countOfSameSingleObject;
                    aux.ValorItemTotal = (countOfSameSingleObject * p.Preco);
                    venda.ListaItemVendidos.Add(aux);
                }

                VendaController controller = new VendaController();
                controller.Create(venda);
                dtCarrinho.Rows.Clear();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home homeScreen = new Home();
            homeScreen.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginScreen = new Login();
            loginScreen.Show();
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

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main mainScreen = new Main();
            mainScreen.Show();
            this.Hide();
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
