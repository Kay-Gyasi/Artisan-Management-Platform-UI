using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Services.HttpServices;
using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AMP.Web.Models.Services.Workers
{
    public class FileToServerUpload : BackgroundService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FileToServerUpload> _logger;
        private readonly IServiceProvider _serviceProvider;
    
        public static IFileListEntry Image;
        public static string AuthToken;
    
        public FileToServerUpload(IWebHostEnvironment environment, 
            ILogger<FileToServerUpload> logger,
            IServiceProvider serviceProvider)
        {
            _environment = environment;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
    
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
                if (Image is null) continue;
                var path = await WriteToDisk(stoppingToken);
                
                if(string.IsNullOrEmpty(AuthToken)) continue;
                var isUploaded = await UploadImage(path);
    
                if (isUploaded) await DeleteImage(path);
            }
        }
    
        private async Task<string> WriteToDisk(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("File detected! Initiating image to directory upload...");
                _logger.LogInformation($"Image: {Image.Name}");
                var path = Path.Combine(_environment.ContentRootPath, "wwwroot", "assets", "Uploads", Image.Name);
                var ms = new MemoryStream();
                await Image.Data.CopyToAsync(ms, stoppingToken);
                await using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                ms.WriteTo(fs);
                Image = null;
                return path;
                _logger.LogInformation("File successfully uploaded to directory...");
            }
            catch (Exception e)
            {
                _logger.LogError("File could not be uploaded to directory!");
                throw;
            }
        }
    
        private async Task<bool> UploadImage(string path)
        {
            try
            {
                _logger.LogInformation("Initiating image upload to server...");
                using var scope = _serviceProvider.CreateScope();
                var imageService = scope.ServiceProvider.GetRequiredService<ImageService>();
                var uploadAsync = await imageService.UploadAsync(path, AuthToken);
                if(uploadAsync) _logger.LogInformation("Image successfully uploaded to server!");
                return uploadAsync;
            }
            catch (Exception e)
            {
                _logger.LogError("Image upload failed!");
                throw;
            }
        }
    
        private Task DeleteImage(string path)
        {
            try
            {
                File.Delete(path);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                _logger.LogError("File was not deleted successfully!");
                throw;
            }
        }
    }
}

