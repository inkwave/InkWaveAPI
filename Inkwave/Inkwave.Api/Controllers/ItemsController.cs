using Inkwave.Application.Features.Items.Queries.GetAllItem;
using Inkwave.Application.Features.Items.Queries.GetItemById;
using Inkwave.Application.Features.Items.Queries.GetItemsWithPagination;
using Inkwave.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inkwave.WebAPI.Controllers
{
    public class ItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllItemsDto>>>> Get()
        {
            return await _mediator.Send(new GetAllItemsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetItemByIdDto>>> GetItemById(Guid id)
        {
            return await _mediator.Send(new GetItemByIdQuery(id));
        }

        //[HttpGet]
        //[Route("paged")]
        //public async Task<ActionResult<PaginatedResult<GetItemsWithPaginationDto>>> GetItemsWithPagination([FromQuery] GetItemsWithPaginationQuery query)
        //{
        //    var validator = new GetItemsWithPaginationValidator();

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
    }
}
