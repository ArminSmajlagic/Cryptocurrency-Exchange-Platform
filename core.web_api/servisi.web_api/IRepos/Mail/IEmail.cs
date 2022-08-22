namespace servisi.trading.IRepos.Mail
{
    public interface IEmailService
    {
        void SendEmail(EmailConfiguration.Mail mail);
    }
}
