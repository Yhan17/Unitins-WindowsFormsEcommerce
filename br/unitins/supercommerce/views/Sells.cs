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
    public partial class Sells : Form
    {
        public Sells()
        {
            InitializeComponent();
        }

        private void Sells_Load(object sender, EventArgs e)
        {
            dtVendas.Rows.Clear();
            VendaController controller = new VendaController();
            List<Venda> lista = controller.Index();
            foreach (Venda p in lista)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dtVendas);
                newRow.Cells[0].Value = p.Total;
                newRow.Cells[1].Value = p.Quantidade;
                newRow.Cells[2].Value = p.Usuario.Nome;
                dtVendas.Rows.Add(newRow);
            }
        }
    }
}
