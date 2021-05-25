using supermercadoEcommerce.br.unitins.supercommerce.dao;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.controllers
{
    class RecoveryController : Controller<Usuario>
    {

        private SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
        {
            Credentials = new NetworkCredential("12896b5688706a", "4c273dcd364323"),
            EnableSsl = true
        };

        public override void Create(Usuario param)
        {
            throw new NotImplementedException();
        }

        public override void Destroy(Usuario param)
        {
            throw new NotImplementedException();
        }

        public override void Edit(Usuario param)
        {
            throw new NotImplementedException();
        }

        public override List<Usuario> Index()
        {
            throw new NotImplementedException();
        }

        public override Usuario Show(int id)
        {
            throw new NotImplementedException();
        }

        public void verifyEmail(string email)
        {
            UsuarioDao dao = new UsuarioDao();
            bool existEmail = dao.VerifyEmail(email);
            if (existEmail)
            {
                String newPassword = dao.UpdatePasswordRecovery(email);
                if (newPassword != null)
                {
                    client.Send("supercommerce@example.com", email, "Recuperação de Senha", $"Olá a senha da sua conta foi alterada Nova Senha: {newPassword}");

                    Console.WriteLine("Sent");
                    Console.ReadLine();
                }
                else
                {
                    MessageBox.Show("Erro, ao Alterar Senha");

                }
            }
            else
            {
                MessageBox.Show("Erro: Email não encontrado na Base de Dados");
            }

        }
    }
}
