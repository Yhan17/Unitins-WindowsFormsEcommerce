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
    public partial class Profile : Form
    {
        private static Usuario usu = new Usuario();

        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            UsuarioController controller = new UsuarioController();
            usu = controller.Show(Convert.ToInt32(Globals.Usu.ID));
            tbNome.Text = usu.Nome;
            tbEmail.Text = usu.Email;
            tbCpf.Text = usu.Cpf;
            tbCep.Text = usu.Endereco.Cep;
            tbAddress.Text = usu.Endereco.EnderecoCompleto;
            tbAdditional.Text = usu.Endereco.Complemento;
            tbDistrict.Text = usu.Endereco.Bairro;
            tbCity.Text = usu.Endereco.Cidade;
            tbUf.Text = usu.Endereco.Uf;
            comprarToolStripMenuItem.Visible = Globals.Usu.TipoUsuario == (TipoUsuario)1;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (tbPassword.Text.Trim() == tbPasswordConfirm.Text.Trim())
                {
                    UsuarioController controller = new UsuarioController();
                    usu.Endereco = new Endereco();
                    usu.Nome = tbNome.Text;
                    usu.Email = tbEmail.Text;
                    usu.Cpf = tbCpf.Text;
                    usu.Endereco.Cep = tbCep.Text;
                    usu.Endereco.EnderecoCompleto = tbAddress.Text;
                    usu.Endereco.Complemento = tbAdditional.Text;
                    usu.Endereco.Bairro = tbDistrict.Text;
                    usu.Endereco.Cidade = tbCity.Text;
                    usu.Endereco.Uf = tbUf.Text;
                    usu.Senha = tbPassword.Text;
                    controller.Edit(usu);
                    Globals.Usu = controller.Show(usu.ID);
                    Clear();
                    Home homeScreen = new Home();
                    homeScreen.Show();
                    this.Hide();
                }else
                {
                    MessageBox.Show("Erro, Senhas Não Coincidem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Erro, Preencha todos os Campos para continuar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Clear()
        {
            tbNome.Text = "";
            tbEmail.Text = "";
            tbCpf.Text = "";
            tbCep.Text = "";
            tbAddress.Text = "";
            tbAdditional.Text = "";
            tbDistrict.Text = "";
            tbCity.Text = "";
            tbUf.Text = "";
            tbPassword.Text = "";
            tbPasswordConfirm.Text = "";
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profileScreen = new Profile();
            profileScreen.Show();
            this.Hide();
        }

        private void tbCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        var resultado = ws.consultaCEP(tbCep.Text);
                        tbAddress.Text = resultado.end;
                        tbAdditional.Text = resultado.complemento2;
                        tbCity.Text = resultado.cidade;
                        tbDistrict.Text = resultado.bairro;
                        tbUf.Text = resultado.uf;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao passar o CEP", "Falha no Cadastro",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        private bool Validate()
        {
            return (tbNome.Text.Trim().Length != 0
                && tbEmail.Text.Trim().Length != 0
                && tbCpf.Text.Trim().Length != 0
                && tbAddress.Text.Trim().Length != 0
                && tbDistrict.Text.Trim().Length != 0
                && tbCity.Text.Trim().Length != 0
                && tbUf.Text.Trim().Length != 0
                && tbPassword.Text.Trim().Length != 0);
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home homeScreen = new Home();
            homeScreen.Show();
        }

        private void listagemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main mainScreen = new Main();
            this.Hide();
            mainScreen.Show();
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
