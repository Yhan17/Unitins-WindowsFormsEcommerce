using supermercadoEcommerce.br.unitins.supercommerce.controllers;
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

namespace supermercadoEcommerce
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register registerScreen = new Register();
            registerScreen.Show();
        }

        private void btnToRecoveryPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecoveryPassword recoveryScreen = new RecoveryPassword();
            recoveryScreen.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginController controller = new LoginController();
            Home homeScreen = new Home();
            bool retorno = controller.Login(tbEmail.Text, tbPassword.Text);
            if (retorno)
            {
                this.Hide();
                homeScreen.Show();
            }
            else
            {
                MessageBox.Show("Erro: login Mal Sucedido", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainScren = new Main();
            mainScren.Show();
        }
    }
}
