using Microsoft.AspNetCore.Http;

namespace Inkwave.Application.Interfaces
{
    public interface IFileWriter
    {
        Task<string> UploadImage(IFormFile file, string folder);
        Task<string> UploadFile(IFormFile file, string folder);

        Task<object> DownloadImage(string folder, string Imagename);
        Task<object> DownloadFile(string folder, string Filename);

    }
}
