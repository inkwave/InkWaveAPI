using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inkwave.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
       
    }
}
