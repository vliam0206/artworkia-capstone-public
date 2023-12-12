namespace WebApi.ViewModels.Commons;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public object? Result { get; set; }
}
