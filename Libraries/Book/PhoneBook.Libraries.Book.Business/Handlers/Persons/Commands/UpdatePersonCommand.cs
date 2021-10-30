using MediatR;
using PhoneBook.Core.Aspects.Autofac.Logging;
using PhoneBook.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.DataAccess.Abstract;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Business.Handlers.Persons.Commands
{
    public class UpdatePersonCommand : IRequest<ResponseMessage<Person>>
    {
        public Person Model { get; set; }
        public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, ResponseMessage<Person>>
        {
            IPersonRepository _personRepository;

            public UpdatePersonCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            [LogAspect(typeof(PostgreSqlLogger))]
            public async Task<ResponseMessage<Person>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.GetAsync(s => s.Id == request.Model.Id);

                if (person == null)
                {
                    return ResponseMessage<Person>.NoDataFound();
                }

                person.Company = request.Model.Company;
                person.Firstname = request.Model.Firstname;
                person.Lastname = request.Model.Lastname;

                _personRepository.Update(person);
                await _personRepository.SaveChangesAsync(true, cancellationToken);
                return ResponseMessage<Person>.Success(request.Model, 200);
            }
        }
    }
}
