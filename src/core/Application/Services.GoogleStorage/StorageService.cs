using Application.AppConfigurations;
using Application.Commons;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;

namespace Application.Services.GoogleStorage;

public class StorageService : IStorageService
{
    private readonly GoogleStorageConfiguration _googleStorageConfiguration;

    public StorageService(AppConfiguration config)
    {
        _googleStorageConfiguration = config.GoogleStorageConfiguration;
    }

    public Task DeleteFileInCloudStorage(string fileName, string folderName)
    {
        throw new NotImplementedException();
    }

    public async Task<MemoryStream> DownloadFileFromCloudStorage(string fileName, string folderName)
    {
        var client = StorageClient.Create();
        var stream = new MemoryStream();
        var obj = await client.DownloadObjectAsync(_googleStorageConfiguration.Bucket, $"{folderName}/{fileName}", stream);
        stream.Position = 0;

        return stream;

    }

    public async Task<string?> UploadFileToCloudStorage(IFormFile files, string fileName, string folderName)
    {
        var client = StorageClient.Create();     
        var obj = await client.UploadObjectAsync(
            _googleStorageConfiguration.Bucket,
            $"{folderName}/{fileName}", 
            files.ContentType, 
            files.OpenReadStream());
        return obj.MediaLink;
    }

    public Task<string?> UploadFileToCloudStorageNoExtension(IFormFile files, string fileName, string folderName)
    {
        throw new NotImplementedException();
    }
}
