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
    public class DeletePersonCommand : IRequest<ResponseMessage<bool>>
    {
        public Guid Id { get; set; }
        public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, ResponseMessage<bool>>
        {
            IPersonRepository _personRepository;

            public DeletePersonCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            [LogAspect(typeof(PostgreSqlLogger))]
            public async Task<ResponseMessage<bool>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.GetAsync(s => s.Id == request.Id);

                if (person == null)
                {
                    return ResponseMessage<bool>.NoDataFound();
                }

                _personRepository.Delete(person);
                await _personRepository.SaveChangesAsync(true, cancellationToken);
                return ResponseMessage<bool>.Success(200);
            }
        }
    }
}
