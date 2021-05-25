using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using supermercadoEcommerce.br.unitins.supercommerce.application;
using supermercadoEcommerce.br.unitins.supercommerce.models;


namespace supermercadoEcommerce.br.unitins.supercommerce.dao
{
    class UsuarioDao : Dao<Usuario>
    {

        public override void Create(Usuario param)
        {
            SqlCommand addressCommand = new SqlCommand("insert into enderecos(cep,endereco,complemento,bairro,cidade,uf) values(@tbCep,@tbEndereco,@tbComplemento,@tbBairro,@tbCidade,@tbUf); SELECT SCOPE_IDENTITY()", Con);
            SqlCommand userCommand = new SqlCommand("insert into usuarios(nome,email,senha,cpf,endereco_id,tipo_usuario) values(@tbNome,@tbEmail,@tbSenha,@tbCpf,@tbUserEndereco,@tipoUsuario)", Con);
            addressCommand.Parameters.Add("@tbCep", SqlDbType.VarChar).Value = param.Endereco.Cep;
            addressCommand.Parameters.Add("@tbEndereco", SqlDbType.VarChar).Value = param.Endereco.EnderecoCompleto;
            addressCommand.Parameters.Add("@tbComplemento", SqlDbType.VarChar).Value = param.Endereco.Complemento;
            addressCommand.Parameters.Add("@tbBairro", SqlDbType.VarChar).Value = param.Endereco.Bairro;
            addressCommand.Parameters.Add("@tbCidade", SqlDbType.VarChar).Value = param.Endereco.Cidade;
            addressCommand.Parameters.Add("@tbUf", SqlDbType.VarChar).Value = param.Endereco.Uf;
            userCommand.Parameters.Add("@tbNome", SqlDbType.VarChar).Value = param.Nome;
            userCommand.Parameters.Add("@tbEmail", SqlDbType.VarChar).Value = param.Email;
            userCommand.Parameters.Add("@tbCpf", SqlDbType.VarChar).Value = param.Cpf;
            userCommand.Parameters.Add("@tbSenha", SqlDbType.VarChar).Value = Utils.ComputeSha256Hash(param.Senha);
            userCommand.Parameters.Add("@tipoUsuario", SqlDbType.Int).Value = param.TipoUsuario;

            if (VerifyEmail(param.Email))
            {
                MessageBox.Show("Erro: Email já presenta na base dee dados", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Con = Connect();
            SqlTransaction tran = Con.BeginTransaction();
            try
            {
                addressCommand.Transaction = tran;
                userCommand.Transaction = tran;
                var id = Convert.ToInt32(addressCommand.ExecuteScalar());
                userCommand.Parameters.Add("@tbUserEndereco", SqlDbType.Int).Value = id;
                userCommand.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("Enviado Com Sucesso");
            }
            catch (SqlException ex)
            {
                tran.Rollback();

                MessageBox.Show("Erro: " + ex.Message);

            }
            finally
            {
                Con = Disconnect();
            }

        }


        public Usuario VerifyLogin(String login, String senha)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Usuario exist = null;

            cmd.CommandText = "select * from usuarios where email = @email and senha = @senha";
            cmd.Parameters.AddWithValue("@email", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    exist = new Usuario();
                    while (dr.Read())
                    {
                        exist.ID = Convert.ToInt32(dr["id"].ToString());
                        exist.Nome = dr["nome"].ToString();
                        exist.Email = dr["email"].ToString();
                        exist.Cpf = dr["cpf"].ToString();
                        exist.TipoUsuario = (TipoUsuario)dr["tipo_usuario"];
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return exist;
        }

        public float TotalComprado(int id)
        {
            float total = 0.0f;
            SqlCommand maxCommand = new SqlCommand("Select DIstinct sum(vendas.total) as total from vendas where vendas.usuario_id = @usuario", Con);
            SqlDataReader dr;

            maxCommand.Parameters.AddWithValue("@usuario", id);

            try
            {
                Connect();
                dr = maxCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["total"].ToString() != "")
                        { 

                            total = Convert.ToSingle(dr["total"].ToString());

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return total;
        }

        public int TotalDeItensAdquiridos(int id)
        {
            int total = 0;
            SqlCommand maxCommand = new SqlCommand("Select sum(vendas.quantidade) as total from vendas where vendas.usuario_id = @usuario", Con);
            SqlDataReader dr;

            maxCommand.Parameters.AddWithValue("@usuario", id);

            try
            {
                Connect();
                dr = maxCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["total"].ToString() != "")
                        {
                            total = Convert.ToInt32(dr["total"].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return total;
        }

        public override void Destroy(Usuario param)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "delete usuarios where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = param.ID;

            try
            {
                Connect();
                cmd.Connection = Con;
                cmd.ExecuteReader();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public override void Edit(Usuario param)
        {
            SqlCommand addressCommand = new SqlCommand("update enderecos set cep=@tbCep,endereco=@tbEndereco,complemento=@tbComplemento,bairro=@tbBairro,cidade=@tbCidade,uf= @tbUf Where id= @tbEnderecoID", Con);
            SqlCommand userCommand = new SqlCommand("update usuarios set nome=@tbNome,email=@tbEmail,senha=@tbSenha,cpf=@tbCpf,tipo_usuario=@tipoUsuario Where id= @tbUsuarioID", Con);
            addressCommand.Parameters.Add("@tbCep", SqlDbType.VarChar).Value = param.Endereco.Cep;
            addressCommand.Parameters.Add("@tbEndereco", SqlDbType.VarChar).Value = param.Endereco.EnderecoCompleto;
            addressCommand.Parameters.Add("@tbComplemento", SqlDbType.VarChar).Value = param.Endereco.Complemento;
            addressCommand.Parameters.Add("@tbBairro", SqlDbType.VarChar).Value = param.Endereco.Bairro;
            addressCommand.Parameters.Add("@tbCidade", SqlDbType.VarChar).Value = param.Endereco.Cidade;
            addressCommand.Parameters.Add("@tbUf", SqlDbType.VarChar).Value = param.Endereco.Uf;
            addressCommand.Parameters.Add("@tbEnderecoID", SqlDbType.Int).Value = param.Endereco.ID;
            userCommand.Parameters.Add("@tbNome", SqlDbType.VarChar).Value = param.Nome;
            userCommand.Parameters.Add("@tbEmail", SqlDbType.VarChar).Value = param.Email;
            userCommand.Parameters.Add("@tbCpf", SqlDbType.VarChar).Value = param.Cpf;
            userCommand.Parameters.Add("@tbSenha", SqlDbType.VarChar).Value = Utils.ComputeSha256Hash(param.Senha);
            userCommand.Parameters.Add("@tipoUsuario", SqlDbType.Int).Value = param.TipoUsuario;
            userCommand.Parameters.Add("@tbUsuarioID", SqlDbType.Int).Value = param.ID;

            if (VerifyEmail(param.Email, param.Email))
            {
                MessageBox.Show("Erro: Email já presenta na base dee dados", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Con = Connect();
            SqlTransaction tran = Con.BeginTransaction();
            try
            {
                addressCommand.Transaction = tran;
                userCommand.Transaction = tran;
                addressCommand.ExecuteNonQuery();
                userCommand.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("Enviado Com Sucesso");
            }
            catch (SqlException ex)
            {
                tran.Rollback();

                MessageBox.Show("Erro: " + ex.Message);

            }
            finally
            {
                Con = Disconnect();
            }
        }

        public override List<Usuario> Index()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Usuario> exist = new List<Usuario>();

            cmd.CommandText = "select * from usuarios order by id";

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Usuario aux = new Usuario();
                        aux.Endereco = new Endereco();
                        aux.ID = Convert.ToInt32(dr["id"].ToString());
                        aux.Nome = dr["nome"].ToString();
                        aux.Email = dr["email"].ToString();
                        aux.Cpf = dr["cpf"].ToString();
                        aux.TipoUsuario = (TipoUsuario)dr["tipo_usuario"];
                        aux.Endereco.ID = Convert.ToInt32(dr["endereco_id"].ToString());
                        exist.Add(aux);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return exist;
        }

        public override Usuario Show(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Usuario exist = new Usuario();
            exist.Endereco = new Endereco();

            cmd.CommandText = "select usuarios.*,enderecos.cep,enderecos.endereco,enderecos.complemento,enderecos.bairro,enderecos.cidade,enderecos.uf from usuarios,enderecos where usuarios.id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                Connect();
                cmd.Connection = Con;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        exist.ID = Convert.ToInt32(dr["id"].ToString());
                        exist.Nome = dr["nome"].ToString();
                        exist.Email = dr["email"].ToString();
                        exist.Cpf = dr["cpf"].ToString();
                        exist.TipoUsuario = (TipoUsuario)dr["tipo_usuario"];
                        exist.Endereco.ID = Convert.ToInt32(dr["endereco_id"].ToString());
                        exist.Endereco.Cep = dr["cep"].ToString();
                        exist.Endereco.Bairro = dr["bairro"].ToString();
                        exist.Endereco.Cidade = dr["cidade"].ToString();
                        exist.Endereco.Complemento = dr["complemento"].ToString();
                        exist.Endereco.EnderecoCompleto = dr["endereco"].ToString();
                        exist.Endereco.Uf = dr["uf"].ToString();


                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return exist;
        }

        public bool VerifyEmail(String email, String editEmail = null)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            bool retorno = false;

            cmd.CommandText = "select * from usuarios where email = @email";

            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                cmd.Connection = Connect();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (editEmail != null)
                    {
                        while (dr.Read())
                        {
                            if (dr["email"].ToString() == editEmail)
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }

                    }
                    else
                    {
                        retorno = true;

                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                _ = Disconnect();
            }
            return retorno;
        }

        public String UpdatePasswordRecovery(String email)
        {
            SqlCommand cmd = new SqlCommand();
            string newPassword = CreateRandomPassword(7);
            cmd.CommandText = "UPDATE usuarios SET senha = @senha where email = @email";
            cmd.Parameters.AddWithValue("@senha", Utils.ComputeSha256Hash(newPassword));
            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                cmd.Connection = Connect();
                cmd.ExecuteNonQuery();
                return newPassword;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return null;
        }

        public static string CreateRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
