using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using UtilityFreamwork.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHost;

        public FileUploader(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public string Uploader(IFormFile file , string path)
        {
            if (file == null) return "";

            var directoryPath = $@"{_webHost.WebRootPath}/ProductPictures/{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $@"{directoryPath}/{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $@"{path}/{fileName}";
        }
    }
}
