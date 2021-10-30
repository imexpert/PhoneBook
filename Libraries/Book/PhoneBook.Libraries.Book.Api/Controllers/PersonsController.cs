using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.WireProtocol.Messages;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Business.Handlers.Persons.Commands;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Api.Controllers
{
    public class PersonsController : BaseApiController
    {
        /// <summary>
        /// Add Person.
        /// </summary>
        /// <param name="createPerson"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<Person>))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Person person)
        {
            return ReturnResult(await Mediator.Send(new CreatePersonCommand() { Model = person}));
        }
    }
}
