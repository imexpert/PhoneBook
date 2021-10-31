using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.WireProtocol.Messages;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Business.Handlers.PersonContacts.Commands;
using PhoneBook.Libraries.Book.Business.Handlers.Persons.Commands;
using PhoneBook.Libraries.Book.Business.Handlers.Persons.Queries;
using PhoneBook.Libraries.Book.Entities.ComplexTypes;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Api.Controllers
{
    public class PersonContactsController : BaseApiController
    {
        /// <summary>
        /// Add PersonContact.
        /// </summary>
        /// <param name="createPersonContact"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<PersonContact>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<PersonContact>))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PersonContact person)
        {
            return ReturnResult(await Mediator.Send(new CreatePersonContactCommand() { Model = person}));
        }

        /// <summary>
        /// Add PersonContact.
        /// </summary>
        /// <param name="createPersonContact"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<bool>))]
        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return ReturnResult(await Mediator.Send(new DeletePersonContactCommand() { Id = id }));
        }
    }
}
