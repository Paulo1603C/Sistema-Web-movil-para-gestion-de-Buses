using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Negocio
{
    public static class EnvioCorreos
    {
        public static bool eviarCorreo(string destinatario, string asunto, string mensaje)
        {
            try
            {
                var cliente = new SmtpClient("smtp.dimsistem.somee.com",25)
                {
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("admin@dimsistem.somee.com", "099010Admin")
                };

                var email = new MailMessage("admin@dimsistem.somee.com", destinatario);
                email.Subject = "Asunto:" + asunto + DateTime.Now.ToLongDateString();
                email.Body = mensaje;
                email.IsBodyHtml = false;
                cliente.Send(email);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }
    }
}
