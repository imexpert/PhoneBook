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
    public class CreatePersonCommand : IRequest<ResponseMessage<Person>>
    {
        public Person Model { get; set; }
        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ResponseMessage<Person>>
        {
            IPersonRepository _personRepository;

            public CreatePersonCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            [LogAspect(typeof(PostgreSqlLogger))]
            public async Task<ResponseMessage<Person>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
            {
                if (await IsPersonExists(request.Model.Firstname))
                {
                    return ResponseMessage<Person>.Fail("Kişi zaten kayıtlı");
                }

                _personRepository.Add(request.Model);
                await _personRepository.SaveChangesAsync(true, cancellationToken);
                return ResponseMessage<Person>.Success(request.Model, 200);
            }

            private async Task<bool> IsPersonExists(string firstName)
            {
                return !(await _personRepository.GetAsync(x => x.Firstname == firstName) is null);
            }
        }
    }
}
