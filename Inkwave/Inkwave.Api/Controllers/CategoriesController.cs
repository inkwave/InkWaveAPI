using Inkwave.Application.Features.Categories.Commands.AddCategory;
using Inkwave.Application.Features.Categories.Commands.UpdateCategory;
using Inkwave.Application.Features.Categorys.Queries;
using Inkwave.Application.Features.Categorys.Queries.GetCategorysWithPagination;
namespace Inkwave.WebAPI.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCategoriesDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Result<GetItemByIdDto>>> GetCategorysById(Guid id)
        //{
        //    return await _mediator.Send(new GetItemByIdQuery(id));
        //}

        //[HttpGet]
        //[Route("paged")]
        //public async Task<ActionResult<PaginatedResult<GetCategorysWithPaginationDto>>> GetCategorysWithPagination([FromQuery] GetCategorysWithPaginationQuery query)
        //{
        //    var validator = new GetCategorysWithPaginationValidator();

        //    // Call Validate or ValidateAsync and pass the object which needs to be validated
        //    var result = validator.Validate(query);

        //    if (result.IsValid)
        //    {
        //        return await _mediator.Send(query);
        //    }

        //    var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        //    return BadRequest(errorMessages);
        //}



        //[HttpPut("{id}")]
        //public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdateItemCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    return await _mediator.Send(command);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Result<Guid>>> Delete(Guid id)
        //{
        //    return await _mediator.Send(new DeleteItemCommand(id));
        //}


        [HttpPost]
        public async Task<ActionResult<Result<Category>>> AddGategory(AddCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Category>>> UpdateGategory(UpdateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }



    }
}
