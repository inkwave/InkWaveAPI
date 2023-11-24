using Inkwave.Application.Features.Orders.Queries.GetOrdersById;
using Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;
using Inkwave.Application.Features.Prints.Commands.AddPrinting;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class PrintingController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public PrintingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<Result<List<GetPrintingByIdDto>>>> GetById(Guid id)
        {
            return await _mediator.Send(new GetPrintingByIdQuery { Id = id });
        }
        [HttpGet()]
        public async Task<ActionResult<Result<List<GetPrintingByUserIdDto>>>> GetByUserId()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new GetPrintingByUserIdQuery
                {
                    UserId = userId
                });
            return Result<List<GetPrintingByUserIdDto>>.Failure("Not Found");
        }
        [HttpPost()]
        public async Task<ActionResult<Result<Guid>>> AddPrinting(AddPrintingCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId) && userId == command.UserId)
            {
                //var filePath = await _FileHandler.UploadFile(data.File, "files\\printing");
                //var imagePath = await _FileHandler.UploadFile(data.CoverImage, "files\\printing");
                //AddPrintingCommand command = new AddPrintingCommand
                //{
                //    UserId = data.UserId,
                //    File = filePath,
                //    BindingOption = data.BindingOption,
                //    PrintingColor = data.PrintingColor,
                //    PaperSize = data.PaperSize,
                //    PaperType = data.PaperType,
                //    PrintingLayou = data.PrintingLayou,
                //    PrintingSide = data.PrintingSide,
                //    CoverImage = imagePath,
                //    CoverBgSize = data.CoverBgSize,
                //    CoverPositionX = data.CoverPositionX,
                //    CoverPositionY = data.CoverPositionY,
                //    CoverRepeat = data.CoverRepeat,
                //    CoverZoom = data.CoverZoom,

                //};
                //command.File = filePath;
                //command.CoverImage = imagePath;
                return await _mediator.Send(command);
            }
            return Result<Guid>.Failure("Not Found");
        }
        //public class AddPrintingDto
        //{
        //    public Guid UserId { get; set; }
        //    public IFormFile File { get; set; }
        //    public string BindingOption { get; set; } = string.Empty;
        //    public string PrintingColor { get; set; } = string.Empty;
        //    public string PaperSize { get; set; } = string.Empty;
        //    public string PaperType { get; set; } = string.Empty;
        //    public string PrintingLayou { get; set; } = string.Empty;
        //    public string PrintingSide { get; set; } = string.Empty;
        //    public IFormFile CoverImage { get; set; }
        //    public string CoverBgSize { get; set; } = string.Empty;
        //    public string CoverPositionX { get; set; } = string.Empty;
        //    public string CoverPositionY { get; set; } = string.Empty;
        //    public string CoverRepeat { get; set; } = string.Empty;
        //    public string CoverZoom { get; set; } = string.Empty;
        //}

    }
}
