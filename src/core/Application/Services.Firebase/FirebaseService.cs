using Application.AppConfigurations;
using Application.Commons;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Sockets;

namespace Application.Services.Firebase;
public class FirebaseService : IFirebaseService
{
    private readonly FirebaseConfiguration _firebaseConfiguration;

    public FirebaseService(AppConfiguration config)
    {
        _firebaseConfiguration = config.FirebaseConfiguration;
    }

    private async Task<string> SignInAndGetAuthToken()
    {
        //Firebase config
        var config = new FirebaseAuthConfig
        {
            ApiKey = _firebaseConfiguration.ApiKey,
            AuthDomain = _firebaseConfiguration.AuthDomain,
            Providers = new FirebaseAuthProvider[]{
                        new EmailProvider()
                    }
        };
        var client = new FirebaseAuthClient(config);
        var authResult = await client.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
        return await authResult.User.GetIdTokenAsync();
    }

    public async Task<string?> UploadFileToFirebaseStorage(IFormFile files, string fileName, string folderName)
    {
        string? urlFile = null;
        if (files.Length > 0)
        {
            var task = new FirebaseStorage(
                _firebaseConfiguration.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = SignInAndGetAuthToken,
                    ThrowOnCancel = true
                })
                .Child(folderName)
                .Child($"{fileName}.{Path.GetExtension(files.FileName).Substring(1)}")
                .PutAsync(files.OpenReadStream(), new CancellationTokenSource().Token);
            urlFile = await task;
        }

        return urlFile;
    }

    public async Task DeleteFileInFirebaseStorage(string fileName, string folderName)
    {
        var task = new FirebaseStorage(
            _firebaseConfiguration.Bucket,
            new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = SignInAndGetAuthToken,
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
