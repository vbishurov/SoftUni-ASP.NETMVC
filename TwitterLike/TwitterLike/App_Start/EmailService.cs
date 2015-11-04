namespace TwitterLike
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using Resources;

    public class EmailService : IIdentityMessageService
    {
        private SmtpClient smtpClient;

        private SmtpClient SmtpClient
        {
            get
            {
                if (this.smtpClient != null)
                {
                    return this.smtpClient;
                }

                this.smtpClient = new SmtpClient();

                var credential = new NetworkCredential
                {
                    UserName = Credentials.GmailServiceUsername,
                    Password = Credentials.GmailServicePassword
                };

                this.smtpClient.Credentials = credential;
                this.smtpClient.Host = Credentials.SmtpHost;
                this.smtpClient.Port = 587;
                this.smtpClient.EnableSsl = true;

                return this.smtpClient;
            }
        }

        public async Task SendAsync(IdentityMessage message)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(message.Destination);
            mailMessage.From = new MailAddress(Credentials.DefaultSenderEmailAddress);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.IsBodyHtml = true;

            using (this.SmtpClient)
            {
                await this.SmtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
