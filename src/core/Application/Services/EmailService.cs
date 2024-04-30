﻿using Application.Commons;
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

    public async Task CreateSampleMailAsync()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory; // Gets the base directory of the assembly
        string relativePath = Path.Combine("EmailTemplates", "BanAccountTemplate.html");
        string filePath = Path.Combine(basePath, relativePath);

        StreamReader streamreader = new(filePath);
        string mailText = streamreader.ReadToEnd();
        streamreader.Close();

        //Replace email informations
        mailText = mailText.Replace("[Username]", "Lam Lam");
        mailText = mailText.Replace("[ViolatedObject]", "Tác phẩm");
        mailText = mailText.Replace("[ObjectName]", "Tên tác phẩm");
        mailText = mailText.Replace("[Reason]", "spam");
        mailText = mailText.Replace("[ResolvedDay]", "1/1/2023");

        await SendMailAsync(new List<string> { "phuhuynh923@gmail.com" },
                "Artworkia - Nền tảng chia sẻ tác phẩm nghệ thuật", mailText);
    }

    public async Task SendMailToViolatedAccountAsync(
        string email, string username, string violatedObject, string objectName, string reason, string? detail, string resolvedDay)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory; // Gets the base directory of the assembly
        string relativePath = Path.Combine("EmailTemplates", "BanAccountTemplate.html");
        string filePath = Path.Combine(basePath, relativePath);

        StreamReader streamreader = new(filePath);
        string mailText = streamreader.ReadToEnd();
        streamreader.Close();

        //Replace email informations
        mailText = mailText.Replace("[Username]", username);
        mailText = mailText.Replace("[ViolatedObject]", violatedObject);
        mailText = mailText.Replace("[ObjectName]", objectName);
        mailText = mailText.Replace("[Reason]", reason);
        mailText = mailText.Replace("[Detail]", detail);
        mailText = mailText.Replace("[ResolvedDay]", resolvedDay);

        await SendMailAsync(new List<string> { email },
                           "[Artworkia] Tài khoản của bạn bị cấm", mailText);
    }   

    public async Task<bool> SendVerificationEmailAsync(string email, string verificationCode)
    {
        var message = @"Xác nhận địa chỉ email của bạn

Hãy chắc chắn đây là địa chỉ email đúng của bạn. Vui lòng nhập mã xác nhận này để tiếp tục đăng kí tài khoản trên hệ thống Artworkia:

" + verificationCode+

@" Mã xác nhận hết hạn sau 15 phút.

Cảm ơn,
Artworkia.";
        return await SendMailAsync(new List<string> { email }, "[Artworkia] Xác thực email", message);
    }
    public async Task<bool> SendMailAsync(List<string> emails, string subject, string message)
    {
        try
        {
            var email = _appConfig.EmailSetting.Email;
            var password = _appConfig.EmailSetting.Password;
            var dispayName = _appConfig.EmailSetting.DisplayName;
            MailMessage myMessage = new();
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
