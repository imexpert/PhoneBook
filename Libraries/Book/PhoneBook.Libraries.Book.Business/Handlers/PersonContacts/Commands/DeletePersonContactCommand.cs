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

namespace PhoneBook.Libraries.Book.Business.Handlers.PersonContacts.Commands
{
    public class DeletePersonContactCommand : IRequest<ResponseMessage<PersonContact>>
    {
        public Guid Id { get; set; }
        public class DeletePersonContactCommandHandler : IRequestHandler<DeletePersonContactCommand, ResponseMessage<PersonContact>>
        {
            IPersonContactRepository _personContactRepository;

            public DeletePersonContactCommandHandler(IPersonContactRepository personContactRepository)
            {
                _personContactRepository = personContactRepository;
            }

            [LogAspect(typeof(PostgreSqlLogger))]
            public async Task<ResponseMessage<PersonContact>> Handle(DeletePersonContactCommand request, CancellationToken cancellationToken)
            {
                var personContact = await _personContactRepository.GetAsync(s => s.Id == request.Id);

                if (personContact == null)
                {
                    return ResponseMessage<PersonContact>.NoDataFound();
                }

                _personContactRepository.Delete(personContact);
                await _personContactRepository.SaveChangesAsync(true, cancellationToken);
                return ResponseMessage<PersonContact>.Success(personContact, 200);
            }
        }
    }
}
