using Inkwave.Application.Interfaces;

namespace Inkwave.WebAPI
{
    public class FileHandler : IFileHandler
    {
        private readonly IFileWriter _FileWriter;
        public FileHandler(IFileWriter FileWriter)
        {
            _FileWriter = FileWriter;
        }

        public async Task<string> UploadImage(IFormFile file, string folder)
        {
            var result = await _FileWriter.UploadImage(file, folder);
            return result;
        }

        public async Task<string> UploadFile(IFormFile file, string folder)
        {
            var result = await _FileWriter.UploadFile(file, folder);
            return Path.Combine(folder, result);
        }

        public async Task<object> DownloadImage(string folder, string Imagename)
        {
            var result = await _FileWriter.DownloadImage(folder, Imagename);
            return result;
        }

        public async Task<object> DownloadFile(string folder, string Filename)
        {
            var result = await _FileWriter.DownloadFile(folder, Filename);
            return result;
        }
    }
}
