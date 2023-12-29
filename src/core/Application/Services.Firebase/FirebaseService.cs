using Application.Commons;
using AutoMapper;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Sockets;

namespace Application.Services.Firebase;
public class FirebaseService : IFirebaseService
{
    private readonly IWebHostEnvironment _environment;
    private readonly AppConfiguration _config;

    public FirebaseService(IWebHostEnvironment environment, AppConfiguration config)
    {
        _environment = environment;
        _config = config;
    }

    public async Task<string?> UploadFileToFirebaseStorage(IFormFile files, string fileName, string folderName)
    {
        var fbConfig = _config.FirebaseConfiguration;
        string? urlFile = null;
        if (files.Length > 0)
        {
            //Firebase config
            var config = new FirebaseAuthConfig
            {
                ApiKey = fbConfig.ApiKey,
                AuthDomain = fbConfig.AuthDomain,
                Providers = new FirebaseAuthProvider[]{
                        new EmailProvider()
                    }
            };
            var client = new FirebaseAuthClient(config);
            var a = await client.SignInWithEmailAndPasswordAsync(fbConfig.AuthEmail, fbConfig.AuthPassword);
            var cancellation = new CancellationTokenSource();

            // luu tam file vao folder trong wwwroot, de sau do upload len firebase
            using (FileStream fileStream = new FileStream(_environment.WebRootPath + $"\\{folderName}\\" + fileName, FileMode.OpenOrCreate))
            {
                files.CopyTo(fileStream);
                fileStream.Seek(0, SeekOrigin.Begin);
                var task = new FirebaseStorage(
                    fbConfig.Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = async () => await a.User.GetIdTokenAsync(),
                        ThrowOnCancel = true
                    })
                    .Child(folderName)
                    .Child($"{fileName}.{Path.GetExtension(files.FileName).Substring(1)}")
                    .PutAsync(fileStream, cancellation.Token);
                urlFile = await task;
                fileStream.Flush();
            }
            // sau khi upload len firebase thi xoa file trong folder
            File.Delete(_environment.WebRootPath + $"\\{folderName}\\" + fileName);
        }

        return urlFile;
    }

    public async Task DeleteFileInFirebaseStorage(string fileName, string folderName)
    {
        var fbConfig = _config.FirebaseConfiguration;

        var config = new FirebaseAuthConfig
        {
            ApiKey = fbConfig.ApiKey,
            AuthDomain = fbConfig.AuthDomain,
            Providers = new FirebaseAuthProvider[]{
                        new EmailProvider()
                    }
        };
        var client = new FirebaseAuthClient(config);
        var a = await client.SignInWithEmailAndPasswordAsync(fbConfig.AuthEmail, fbConfig.AuthPassword);
        var cancellation = new CancellationTokenSource();

        var task = new FirebaseStorage(
            fbConfig.Bucket,
            new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = async () => await a.User.GetIdTokenAsync(),
                ThrowOnCancel = true
            })
            .Child(folderName)
            .Child(fileName)
            .DeleteAsync();
        try
        {
            await task;
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
