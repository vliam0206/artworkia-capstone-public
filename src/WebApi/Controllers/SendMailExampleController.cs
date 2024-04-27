using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SendMailExampleController : ControllerBase
{
    private readonly IEmailService _emailService;

    public SendMailExampleController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    // POST: api/SendMailExample
    [HttpPost]
    public async Task<IActionResult> SendMailExample([FromBody] EmailExamModel model)
    {
        try
        {
            // file path in localhost
            // Nhớ sửa lại file template html
            string exePath = Environment.CurrentDirectory.ToString();
            if (exePath.Contains(@"\bin\Debug\net7.0"))
                exePath = exePath.Remove(exePath.Length - (@"\bin\Debug\net7.0").Length);
            string FilePath = exePath + @"\EmailTemplates\DefaultTemplate.html";

            //// file path when deploy to server
            //// đổi lại đường dẫn file template html
            //string FilePath = "/app/SenikWebApi/EmailTemplates/DefaultTemplate.html"; 

            StreamReader streamreader = new StreamReader(FilePath);
            string mailText = streamreader.ReadToEnd();
            streamreader.Close();
            //Replace email informations
            mailText = mailText.Replace("[CustomerFullName]", "Tên khách hàng là Lam Lam");
            mailText = mailText.Replace("[Address]", "Địa chỉ của tui");
            mailText = mailText.Replace("[PhoneNumber]", "090xxxxxxxxx");
            mailText = mailText.Replace("[CreatedDate]", "xx/xx/xxx");
            mailText = mailText.Replace("[Total]", "100.000 VND");
            // Send email to customer (send reservation information)
            await _emailService.SendMailAsync(new List<string> { model.Email }, "Senik - Xác nhận đơn hàng", mailText);
            return Ok(new {Message = "Đã gửi mail thành công" });
        } catch (Exception ex) 
        {
            return StatusCode(500, new {ErrorMessage = ex.Message});
        }
    }
}

public class EmailExamModel
{
    [Required]
    public string Email { get; set; } = default!;
}
