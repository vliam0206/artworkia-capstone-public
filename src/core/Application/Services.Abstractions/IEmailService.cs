namespace Application.Services.Abstractions;

public interface IEmailService
{
    public Task CreateSampleMailAsync();
    public Task SendMailToViolatedAccountAsync(
        string email, string username, string violatedObject, string objectName, 
        string reason, string? detail, string resolvedDay);
    public Task<bool> SendMailAsync(List<string> email, string subject, string message);
}
