using Microsoft.AspNetCore.Http;

namespace Application.Services.GoogleStorage;

public interface IStorageService
{

    /// <summary>
    /// Upload file len cloud storage, cung co the thay the file cung duong dan va ten
    /// </summary>
    /// <returns>tra ve url file</returns>
    Task<string?> UploadFileToCloudStorage(IFormFile files, string fileName, string folderName);
    /// <summary>
    /// Upload file len cloud storage, cung co the thay the file cung duong dan va ten
    /// ten file upload khong co duoi file
    /// </summary>
    /// <returns>tra ve url file</returns>
    Task<string?> UploadFileToCloudStorageNoExtension(IFormFile files, string fileName, string folderName);

    /// <summary>
    /// Xoa file tren storage
    /// </summary>
    Task DeleteFileInCloudStorage(string fileName, string folderName);

    /// <summary>
    /// lay url download file tu storage
    /// </summary>
    /// <returns>lay url download file tu storage</returns>
    Task<MemoryStream> DownloadFileFromCloudStorage(string fileName, string folderName);

    /// <summary>
    /// lay thong tin file tu storage
    /// </summary>
    /// <returns>tra ve object GoogleMetaData chua cac thong tin file</returns>
    //Task<GoogleMetaData?> GetMetadataFileFromGoogleStorage(string fileName, string folderName);
}
