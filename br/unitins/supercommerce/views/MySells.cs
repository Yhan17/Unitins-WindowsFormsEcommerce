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
    public partial class MySells : Form
    {
        public MySells()
        {
            InitializeComponent();
        }

        private void MySells_Load(object sender, EventArgs e)
        {
            dtMyVendas.Rows.Clear();
            VendaController controller = new VendaController();
            List<Venda> lista = controller.MyIndex();
            foreach (Venda p in lista)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dtMyVendas);
                newRow.Cells[0].Value = p.Total;
                newRow.Cells[1].Value = p.Quantidade;
                newRow.Cells[2].Value = p.Usuario.Nome;
                dtMyVendas.Rows.Add(newRow);
            }
        }
    }
}
