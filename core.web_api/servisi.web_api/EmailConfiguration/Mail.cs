using MimeKit;

namespace servisi.trading.EmailConfiguration
{
    public class Mail
    {
        public MailboxAddress To { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }
        public string name { get; set; }

        public Mail(string to, string subj, string cont, string name)
        {
            To = new MailboxAddress(name, to);
            Subject = subj;
            Content = cont;
            this.name = name;
        }
    }
}
