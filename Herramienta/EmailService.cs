using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Herramienta
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient("sandbox.smtp.mailtrap.io", 2525);
            server.Credentials = new NetworkCredential("506ca30e2c5e8f", "1675e7789d81a0");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "sandbox.smtp.mailtrap.io";
        }
        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            //email.From = new MailAddress("noresponder@prueba.com");
            email.From = new MailAddress("ArticulosPitucos@mailtrap.com", "Articulos Pitucos");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;
        }
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
