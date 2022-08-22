using MailKit.Net.Smtp;
using MimeKit;
using servisi.trading.EmailConfiguration;
using servisi.trading.IRepos.Mail;

namespace servisi.trading.Repos.Security.Verification
{
    public class EmailServis : IEmailService
    {
        private readonly EmailConfig configration;
        private readonly ILogger logger;

        public EmailServis(EmailConfig configration)
        {
            this.configration = configration;
        }

        public async void SendEmail(Mail mail)
        {
            var emailMessage = CreateEmailMessage(mail);

            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(configration.smtpServer, configration.port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(configration.username, configration.password);
                    client.Send(emailMessage);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.InnerException);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(Mail mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Dobrodošli " + mail.name, configration.from));
            message.To.Add(mail.To);
            message.Subject = mail.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = mail.Content };
            return message;
        }
    }
}
