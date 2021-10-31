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
    public class CreatePersonContactCommand : IRequest<ResponseMessage<PersonContact>>
    {
        public PersonContact Model { get; set; }
        public class CreatePersonContactCommandHandler : IRequestHandler<CreatePersonContactCommand, ResponseMessage<PersonContact>>
        {
            IPersonContactRepository _personContactRepository;

            public CreatePersonContactCommandHandler(IPersonContactRepository personContactRepository)
            {
                _personContactRepository = personContactRepository;
            }

            public async Task<ResponseMessage<PersonContact>> Handle(CreatePersonContactCommand request, CancellationToken cancellationToken)
            {
                _personContactRepository.Add(request.Model);
                await _personContactRepository.SaveChangesAsync(true, cancellationToken);
                return ResponseMessage<PersonContact>.Success(request.Model, 200);
            }
        }
    }
}
