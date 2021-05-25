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
    public partial class Product : Form
    {
        private static Produto prod = new Produto();

        public Product()
        {
            InitializeComponent();
        }

        private void tbDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbDescription_Click(object sender, EventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoController controller = new ProdutoController();
                controller.Destroy(prod);
                MessageBox.Show("Deletado com Sucesso");
                btnDeletar.Enabled = false;
                Clear();
                GenerateDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Validate())
            {

                Produto newProd = new Produto();
                ProdutoController controller = new ProdutoController();
                newProd.Categoria = new Categoria();
                newProd.Nome = tbNome.Text;
                newProd.Descricao = tbDescricao.Text;
                newProd.Preco = Convert.ToSingle(tbPreco.Value);
                newProd.Estoque = Convert.ToInt32(tbEstoque.Value);
                newProd.Categoria = (Categoria)tbCategoria.SelectedItem;
                if (btnSalvar.Text == "Update")
                {
                    prod.Categoria = new Categoria();
                    prod.Nome = tbNome.Text;
                    prod.Descricao = tbDescricao.Text;
                    prod.Preco = Convert.ToSingle(tbPreco.Value);
                    prod.Estoque = Convert.ToInt32(tbEstoque.Value);
                    prod.Categoria = (Categoria)tbCategoria.SelectedItem;
                    controller.Edit(prod);
                }
                else
                {
                    btnDeletar.Enabled = true;

                    controller.Create(newProd);

                }
                GenerateDataGridView();
                Clear();
            }
            else
            {
                MessageBox.Show("Erro, Preencha o campos para continuar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool Validate()
        {
            Console.WriteLine(tbNome.Text.Trim().Length != 0);
            Console.WriteLine(Convert.ToSingle(tbPreco.Value) > 0);
            Console.WriteLine(Convert.ToInt32(tbEstoque.Value) > 0);
            return (tbNome.Text.Trim().Length != 0
                && Convert.ToSingle(tbPreco.Value) > 0
                && Convert.ToInt32(tbEstoque.Value) > 0
                && tbCategoria.SelectedIndex > -1);
        }
        private void Product_Load(object sender, EventArgs e)
        {

            tbCategoria.DisplayMember = "Nome";
            tbCategoria.ValueMember = "ID";

            CategoriaController controller = new CategoriaController();

            List<Categoria> list = new List<Categoria>();

            list = controller.Index();

            foreach (Categoria cat in list)
            {
                tbCategoria.Items.Add(cat);
            }
            GenerateDataGridView();

        }

        private void tbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Clear()
        {
            tbNome.Text = "";
            tbDescricao.Text = "";
            tbPreco.Value = 0;
            tbEstoque.Value = 0;
            tbCategoria.SelectedIndex = -1;
            btnSalvar.Text = "Salvar";
            btnDeletar.Enabled = false;
        }

        private void GenerateDataGridView()
        {
            dtProducts.Rows.Clear();
            ProdutoController controller = new ProdutoController();
            List<Produto> data = controller.Index();
            foreach (Produto row in data)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dtProducts);
                newRow.Cells[0].Value = row.ID;
                newRow.Cells[1].Value = row.Nome;
                newRow.Cells[2].Value = row.Preco.ToString();
                newRow.Cells[3].Value = row.Estoque.ToString();
                newRow.Cells[4].Value = row.Categoria.ID;
                dtProducts.Rows.Add(newRow);
            }
        }

        private void dtProducts_DoubleClick(object sender, EventArgs e)
        {
            if (dtProducts.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(dtProducts.CurrentRow.Cells["ProductID"].Value);
                ProdutoController controller = new ProdutoController();
                prod = controller.Show(id);
                tbNome.Text = prod.Nome;
                tbDescricao.Text = prod.Descricao;
                tbEstoque.Value = prod.Estoque;
                tbPreco.Text = prod.Preco.ToString();
                foreach (Categoria cat in tbCategoria.Items)
                {
                    if (cat.ID == prod.Categoria.ID)
                    {
                        tbCategoria.SelectedItem = cat;
                    }
                }
                btnSalvar.Text = "Update";
                btnDeletar.Enabled = true;
            }
        }
    }
}
