using supermercadoEcommerce.br.unitins.supercommerce.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    public partial class RecoveryPassword : Form
    {
        public RecoveryPassword()
        {
            InitializeComponent();
        }



        private void btnRecovery_Click_1(object sender, EventArgs e)
        {
            RecoveryController controller = new RecoveryController();
            if (tbEmailRecovery.Text != null || tbEmailRecovery.Text != "")
            {
                controller.verifyEmail(tbEmailRecovery.Text);
                MessageBox.Show("Email de alteração de senha mandado", "Alteração de senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Erro: Email não encontrado na Base de Dados", "Campo Não Preenchido", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainScren = new Main();
            mainScren.Show();
        }
    }
}
