using Microsoft.AspNetCore.Http;

namespace Application.Services.Firebase;
public interface IFirebaseService
{
    Task<string?> UploadFileToFirebaseStorage(IFormFile files, string fileName, string folderName);
}
