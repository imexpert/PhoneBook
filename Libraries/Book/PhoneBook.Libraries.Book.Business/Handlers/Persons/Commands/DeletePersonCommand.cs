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
    public class DeletePersonCommand : IRequest<ResponseMessage<Person>>
    {
        public Guid Id { get; set; }
        public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, ResponseMessage<Person>>
        {
            IPersonRepository _personRepository;
            IPersonContactRepository _personContactRepository;

            public DeletePersonCommandHandler(
                IPersonRepository personRepository,
                IPersonContactRepository personContactRepository)
            {
                _personRepository = personRepository;
                _personContactRepository = personContactRepository;
            }

            [LogAspect(typeof(PostgreSqlLogger))]
            public async Task<ResponseMessage<Person>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.GetAsync(s => s.Id == request.Id);

                if (person == null)
                {
                    return ResponseMessage<Person>.NoDataFound();
                }

                var contactList = await _personContactRepository.GetListAsync(s => s.PersonId == person.Id);

                if (contactList.Count() > 0)
                {
                    return ResponseMessage<Person>.Fail("Kişi detay bilgisi varken silme yapılamaz.");
                }

                _personRepository.Delete(person);
                await _personRepository.SaveChangesAsync(true, cancellationToken);
                return ResponseMessage<Person>.Success(200);
            }
        }
    }
}
