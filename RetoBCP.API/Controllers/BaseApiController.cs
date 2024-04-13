using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetoBCP.Application.Core;

namespace RetoBCP.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private readonly IConfiguration _config;        
        public BaseApiController(IConfiguration Config)
        {            
            _config = Config;
        }

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound();
            if (result.IsSuccess && result.Value != null)            
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NoContent();
            if (!result.IsAuthorized)
                return Unauthorized(result.Error);
            if (!result.IsAllowedToAccess)
                return Forbid();
            return BadRequest(result.Error);
        }
    }
}
