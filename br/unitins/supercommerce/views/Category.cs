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
    public partial class Category : Form
    {
        private static Categoria cat = new Categoria();

        public Category()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Validate())
            {

                Categoria newCat = new Categoria();
                CategoriaController controller = new CategoriaController();

                newCat.Nome = tbNome.Text;
                newCat.Descricao = tbDescricao.Text;
                if (btnSalvar.Text == "Update")
                {
                    cat.Nome = tbNome.Text;
                    cat.Descricao = tbDescricao.Text;
                    controller.Edit(cat);
                }
                else
                {
                    btnDeletar.Enabled = true;

                    controller.Create(newCat);

                }
                GenerateDataGridView();
                Clear();
            }
            else
            {
                MessageBox.Show("Erro, Preencha o campo Nome para continuar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateDataGridView()
        {
            dtCategorias.Rows.Clear();
            CategoriaController controller = new CategoriaController();
            List<Categoria> data = controller.Index();
            foreach (Categoria row in data)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dtCategorias);
                newRow.Cells[0].Value = row.ID;
                newRow.Cells[1].Value = row.Nome;
                dtCategorias.Rows.Add(newRow);
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            GenerateDataGridView();
        }

        private void dtCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtCategorias_DoubleClick(object sender, EventArgs e)
        {
            if (dtCategorias.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(dtCategorias.CurrentRow.Cells["CategoryId"].Value);
                CategoriaController controller = new CategoriaController();
                cat = controller.Show(id);
                tbNome.Text = cat.Nome;
                tbDescricao.Text = cat.Descricao;
                btnSalvar.Text = "Update";
                btnDeletar.Enabled = true;
            }
        }
        private bool Validate()
        {
            return (tbNome.Text.Trim().Length != 0);
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaController controller = new CategoriaController();
                controller.Destroy(cat);
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

        private void Clear()
        {
            tbNome.Text = "";
            tbDescricao.Text = "";
            btnSalvar.Text = "Salvar";
            btnDeletar.Enabled = false;
        }
    }
}
