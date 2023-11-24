
using Inkwave.Application.Interfaces;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class FileController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileHandler _FileHandler;
        public FileController(IMediator mediator, IFileHandler fileHandler)
        {
            _mediator = mediator;
            _FileHandler = fileHandler;
        }
        [HttpPost()]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var path = await _FileHandler.UploadFile(file, "files\\printing");
                return Ok(path);

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);

            }
        }

        [HttpGet()]
        [Route("DownloadFileService/{filename}")]
        public async Task<IActionResult> DownloadFileService(string filename)
        {
            var path = await _FileHandler.DownloadFile(filename, "files\\printing");
            return Ok(path);
        }


        [HttpPost()]
        [Route("UploadImageAvatar")]
        public async Task<IActionResult> UploadImageAvatar(IFormFile file)
        {
            try
            {
                var path = await _FileHandler.UploadImage(file, "images\\avatar");
                var Userid = User.Claims.First(s => s.Type.ToString().Contains("Userid")).Value;
                // var result = await _iuserRepository.UpdateImage(path, int.Parse(Userid));
                return Ok();

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);

            }
        }
        [HttpPost()]
        [Route("UploadImageService")]
        public async Task<IActionResult> UploadImageService(IFormFile file)
        {
            var path = await _FileHandler.UploadImage(file, "images\\service");
            return Ok(path);
        }


        [HttpGet()]
        [Route("DownloadImageAvatar/{imagename}")]
        public async Task<IActionResult> DownloadImageAvatar(string imagename)
        {
            var path = await _FileHandler.DownloadImage(imagename, "images\\avatar");
            return Ok(path);
        }
        [HttpGet()]
        [Route("DownloadImageService/{imagename}")]
        public async Task<IActionResult> DownloadImageService(string imagename)
        {
            var path = await _FileHandler.DownloadImage(imagename, "images\\service");
            return Ok(path);
        }
    }
}


