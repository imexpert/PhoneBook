using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.WireProtocol.Messages;
using PhoneBook.Core.Utilities.Results;
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

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<Person>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<List<Person>>))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetPersonsQuery command = new GetPersonsQuery();

            return ReturnResult(await Mediator.Send(command));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<PersonDetailModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<PersonDetailModel>))]
        [HttpGet]
        public async Task<IActionResult> GetPersonDetail(Guid id)
        {
            GetPersonDetailQuery command = new GetPersonDetailQuery() { Id = id };

            return ReturnResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Add PersonContact.
        /// </summary>
        /// <param name="createPersonContact"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<Person>))]
        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return ReturnResult(await Mediator.Send(new DeletePersonCommand() { Id = id }));
        }
    }
}
