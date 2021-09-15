using Microsoft.AspNetCore.Http;

namespace UtilityFreamwork.Application
{
    public interface IFileUploader
    {
        string Uploader(IFormFile file , string path);
    }
}
