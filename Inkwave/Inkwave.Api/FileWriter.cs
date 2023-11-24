using Inkwave.Application.Extensions;
using Inkwave.Application.Interfaces;
using Inkwave.Domain.Document;

namespace Inkwave.WebAPI
{
    public class FileWriter : IFileWriter
    {
        public async Task<string> UploadFile(IFormFile file, string folder)
        {
            if (CheckIfFile(file))
                return await WriteFile(file, folder);

            return "Invalid file";
        }

        public async Task<string> UploadImage(IFormFile file, string folder)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file, folder);
            }

            return "Invalid image file";
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfFile(IFormFile file)
        {

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return fileBytes.GetFileFormat() != FileFormat.unknown;
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return fileBytes.GetImageFormat() != ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file, string folder)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + folder);
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                var path = Path.Combine(directory, fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }

        public async Task<object> DownloadImage(string folder, string Imagename)
        {
            if (Imagename == null)
                return "Imagename not present";

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", Imagename);

            var image = File.OpenRead(path);
            await File.ReadAllBytesAsync(path);

            return image;

        }

        public async Task<object> DownloadFile(string folder, string Filename)
        {
            if (Filename == null)
                return "Imagename not present";

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", Filename);

            var file = File.OpenRead(path);
            await File.ReadAllBytesAsync(path); // File.OpenRead(path);

            return file;


        }
    }
}
