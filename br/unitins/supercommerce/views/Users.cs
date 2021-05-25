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
    public partial class Users : Form
    {
        private static Usuario usu = new Usuario();

        public Users()
        {
            InitializeComponent();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioController controller = new UsuarioController();
                controller.Destroy(usu);
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
                if (tbPassword.Text.Trim() == tbPasswordConfirm.Text.Trim())
                {
                    UsuarioController controller = new UsuarioController();
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
                    usuario.TipoUsuario = (TipoUsuario)(tbUserType.SelectedIndex + 1);
                    if (btnSalvar.Text == "Update")
                    {
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
                        usu.TipoUsuario = (TipoUsuario)(tbUserType.SelectedIndex + 1);
                        controller.Edit(usu);
                    }
                    else
                    {
                        btnDeletar.Enabled = true;

                        controller.Create(usuario);

                    }
                    GenerateDataGridView();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            tbUserType.SelectedIndex = -1;
            btnSalvar.Text = "Salvar";
            btnDeletar.Enabled = false;
        }

        private void GenerateDataGridView()
        {
            dtUsers.Rows.Clear();
            UsuarioController controller = new UsuarioController();
            List<Usuario> data = controller.Index();
            foreach (Usuario row in data)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dtUsers);
                newRow.Cells[0].Value = row.ID;
                newRow.Cells[1].Value = row.Nome;
                newRow.Cells[2].Value = row.Email;
                newRow.Cells[3].Value = row.Cpf;
                newRow.Cells[4].Value = (TipoUsuario)row.TipoUsuario;
                dtUsers.Rows.Add(newRow);
            }
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

        private void dtUsers_DoubleClick(object sender, EventArgs e)
        {
            if (dtUsers.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(dtUsers.CurrentRow.Cells["UserId"].Value);
                UsuarioController controller = new UsuarioController();
                usu = controller.Show(id);
                tbNome.Text = usu.Nome;
                tbEmail.Text = usu.Email;
                tbCpf.Text = usu.Cpf;
                tbCep.Text = usu.Endereco.Cep;
                tbAddress.Text = usu.Endereco.EnderecoCompleto;
                tbAdditional.Text = usu.Endereco.Complemento;
                tbDistrict.Text = usu.Endereco.Bairro;
                tbCity.Text = usu.Endereco.Cidade;
                tbUf.Text = usu.Endereco.Uf;
                Console.WriteLine((int)(usu.TipoUsuario));
                tbUserType.SelectedValue = (int)(usu.TipoUsuario);
                btnSalvar.Text = "Update";
                btnDeletar.Enabled = true;
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
                && tbPassword.Text.Trim().Length != 0
                && tbUserType.SelectedIndex > -1);
        }

        private void Users_Load(object sender, EventArgs e)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, "Administrador");
            dict.Add(2, "Consumidor");
            tbUserType.DisplayMember = "Value";
            tbUserType.ValueMember = "Key";
            tbUserType.DataSource = new BindingSource(dict, null);
            GenerateDataGridView();
        }
    }
}
