using Application.Commons;
using Application.Services.Abstractions;
using System.Net.Mail;
using System.Net;

namespace Application.Services;

public class EmailService : IEmailService
{
    private readonly AppConfiguration _appConfig;

    public EmailService(AppConfiguration appConfiguration)
    {
        _appConfig = appConfiguration;
    }
    public async Task<bool> SendMailAsync(List<string> emails, string subject, string message)
    {
        try
        {
            var email = _appConfig.EmailSetting.Email;
            var password = _appConfig.EmailSetting.Password;
            var dispayName = _appConfig.EmailSetting.DisplayName;
            MailMessage myMessage = new MailMessage();
            foreach (var mail in emails)
            {
                myMessage.To.Add(mail);
            }
            myMessage.IsBodyHtml = true;
            myMessage.From = new MailAddress(email, dispayName);
            myMessage.Subject = subject;
            myMessage.Body = message;
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(email, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                await smtp.SendMailAsync(myMessage);
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
