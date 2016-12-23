using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HexaCore.Tickets.Services.Email
{
    public static class Email
    {
        public static Tuple<bool, string> EnviarEmail(string[] destinatarios, string[] cc, string[] bcc, string assunto, string corpo, string[] urlAnexos)
        {
            var email = new MailMessage();
            var smtp = ConfiguraSmtp();

            email.IsBodyHtml = true;
            email.From = new MailAddress("emailmobteste@gmail.com");
            destinatarios.ToList().ForEach(d => email.To.Add(d));
            if(cc != null)
                cc.ToList().ForEach(copia => email.CC.Add(copia));
            if (bcc != null)
                bcc.ToList().ForEach(copiaOculta => email.Bcc.Add(copiaOculta));
            if (urlAnexos != null)
                urlAnexos.ToList().ForEach(anexo => email.Attachments.Add(new Attachment(anexo)));
            email.Subject = assunto;
            email.Body = corpo;

            try
            {
                smtp.Send(email);
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false, e.Message);
            }

            email.Dispose();
            smtp.Dispose();

            return new Tuple<bool, string>(true, "Email enviado com sucesso");
        }

        private static SmtpClient ConfiguraSmtp()
        {
            var host = "smtp.gmail.com";
            var porta = 587;

            SmtpClient smtp = new SmtpClient(host, porta);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("emailmobteste@gmail.com", "execplan");

            return smtp;
        }
    }
}
