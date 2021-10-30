using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Utilities.Results;

namespace PhoneBook.Libraries.Book.Api.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController : Controller
    {
        private IMediator _mediator;
        /// <summary>
        /// It is for getting the Mediator instance creation process from the base controller.
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ReturnResult<T>(ResponseMessage<T> response)
        {
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
