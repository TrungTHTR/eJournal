using Application.InterfaceService;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IConfiguration _configuration;

        public FirebaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private async Task<string> GetFirebaseAuthenticationToken()
        {
            FirebaseAuthConfig config = new FirebaseAuthConfig
            {
                ApiKey = _configuration["firebase:apiKey"],
                AuthDomain = _configuration["firebase:authDomain"],
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            FirebaseAuthClient authClient = new FirebaseAuthClient(config);
            var credential = await authClient.SignInWithEmailAndPasswordAsync(_configuration["googleAccount:email"], _configuration["googleAccount:password"]);
            var token = await credential.User.GetIdTokenAsync();
            return token;
        }

        private async Task<FirebaseStorage> GetFirebaseStorage()
        {
            var authToken = await GetFirebaseAuthenticationToken();
            var storage = new FirebaseStorage(
                _configuration["firebase:storageBucket"],
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authToken),
                    ThrowOnCancel = true
                });
            return storage;
        }

        public async Task DownloadFile(string url)
        {
            var storage = await GetFirebaseStorage();
            using(Stream downloadFileStream = new FileStream($"abc", FileMode.CreateNew))
            {
                await WebRequest.Create(url).GetResponseAsync().ContinueWith(task => task.Result.GetResponseStream().CopyToAsync(downloadFileStream));
            }
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName, string? folder = null)
        {
            var storage = await GetFirebaseStorage();
            string url;
            if(folder != null)
            {
                url = await storage.Child(folder).Child($"{Guid.NewGuid()}.{GetFileExtension(fileName)}").PutAsync(fileStream);
            } else
            {
                url = await storage.Child($"{Guid.NewGuid()}.{GetFileExtension(fileName)}").PutAsync(fileStream);
            }
            return url;
        }

        private string GetFileExtension(string fileName)
        {
            string[] list = fileName.Split('.', StringSplitOptions.RemoveEmptyEntries);
            return list.Last();
        }
    }
}
