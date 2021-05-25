using supermercadoEcommerce.br.unitins.supercommerce.controllers;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

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

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (tbPassword.Text.Trim() == tbPasswordConfirm.Text.Trim())
                {

                    Usuario usuario = new Usuario();
                    usuario.Endereco = new Endereco();
                    usuario.Nome = tbNome.Text;
                    usuario.Email = tbEmail.Text;
                    usuario.Cpf = tbCpf.Text;
                    usuario.Endereco.Cep = tbCep.Text;
                    usuario.Endereco.EnderecoCompleto = tbAddress.Text;
                    usuario.Endereco.Complemento = tbAdditional.Text;
                    usuario.Endereco.Bairro = tbDistrict.Text;
                    usuario.Endereco.Cidade = tbCity.Text;
                    usuario.Endereco.Uf = tbUf.Text;
                    usuario.Senha = tbPassword.Text;
                    usuario.TipoUsuario = (TipoUsuario)2;
                    RegisterController controller = new RegisterController();
                    controller.Create(usuario);
                    Clear();
                }
                else
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
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainScren = new Main();
            mainScren.Show();
        }
    }
}
