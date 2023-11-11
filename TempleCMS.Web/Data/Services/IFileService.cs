using TempleCMS.Web.Models;

namespace TempleCMS.Web.Data.Services
{
    public interface IFileService
    {
        Task<string> ImageUpload(IFormFile upload, string directory);
        void RemoveOldImage(string oldImage, string directory);
    }
}