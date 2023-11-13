using JNHAutos.Domain;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JNHAutos.Data
{
    public class EmailRepository : IEmailRepository
    {
        private EmailConfig smtpConfig = new EmailConfig();

        private const string SMTP_CONFIG_SECTION = "Turn2Digital.Mail";

        public EmailRepository(IConfiguration configuration)
        {
            if (!configuration.GetChildren().Any(item => item.Key == SMTP_CONFIG_SECTION))
            {
                throw new ApplicationException($"Missing section from appsettings.json : [{SMTP_CONFIG_SECTION}]");
            }

            configuration.GetSection(SMTP_CONFIG_SECTION).Bind(smtpConfig);
        }

        public async Task SendContactEmail(string name, string email, string phoneNumber, string message)
        {
            if (smtpConfig.Debug)
            {
                Console.WriteLine("Email sending in debug.");
            }
            else
            {
                var apiKey = smtpConfig.ApiKey;
                var sendToEmail = smtpConfig.SendToEmail;
                var sendToName = smtpConfig.SendToName;

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(sendToEmail, name);
                var subject = "JNH Autos Website Form";

                var to = new EmailAddress(sendToEmail, sendToName);
                var plainTextContent = message + "Phone number: " + phoneNumber + "Email: " + email;
                var htmlContent = message + "<br><br>Phone number: " + phoneNumber + "<br><br>Email:" + email;

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }
    }
}