using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace BL
{
    public class MailService : IMailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly bool _smtpEnableSsl;

        public MailService(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword, bool smtpEnableSsl)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
            _smtpEnableSsl = smtpEnableSsl;
        }

        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var mimeMessage = new MimeMessage();
        //    mimeMessage.From.Add(new MailboxAddress(_smtpUsername, _smtpUsername));
        //    mimeMessage.To.Add(new MailboxAddress(email, email));
        //    mimeMessage.Subject = subject;
        //    mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };

        //    using (var client = new SmtpClient())
        //    {
        //        // Use the "None" secure socket option to ignore SSL/TLS
        //        await client.ConnectAsync(_smtpHost, _smtpPort, MailKit.Security.SecureSocketOptions.None);

        //        // Provide a custom ServerCertificateValidationCallback that always returns true
        //        client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };

        //        await client.SendAsync(mimeMessage);
        //        await client.DisconnectAsync(true);
        //    }
        //}

        public async Task SendEmail(string destinataire, string sujet, string corps, byte[] PieceJointe, string namePieceJointe)
        {
            try
            {
                var smtpClient = new SmtpClient(_smtpHost)
                {
                    Port = _smtpPort,
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = _smtpEnableSsl,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = sujet,
                    Body = corps,
                };

                message.To.Add(destinataire);
                if (PieceJointe != null && PieceJointe.Length > 0)
                {
                    var attachment = new Attachment(new MemoryStream(PieceJointe), $"{namePieceJointe}" + ".pdf");
                    message.Attachments.Add(attachment);
                }
                var test = JsonConvert.SerializeObject(message);
                //await smtpClient.SendMailAsync(message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }
    }
    }
