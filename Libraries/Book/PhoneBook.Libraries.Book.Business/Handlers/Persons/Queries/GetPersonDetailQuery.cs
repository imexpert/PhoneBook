using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.DataAccess.Abstract;
using PhoneBook.Libraries.Book.Entities.ComplexTypes;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Business.Handlers.Persons.Queries
{
    public class GetPersonDetailQuery : IRequest<ResponseMessage<PersonDetailModel>>
    {
        public Guid Id { get; set; }

        public class GetPersonDetailQueryHandler : IRequestHandler<GetPersonDetailQuery, ResponseMessage<PersonDetailModel>>
        {
            private readonly IPersonRepository _personRepository;
            private readonly IPersonContactRepository _personContactRepository;

            public GetPersonDetailQueryHandler(
                IPersonRepository personRepository,
                IPersonContactRepository personContactRepository)
            {
                _personRepository = personRepository;
                _personContactRepository = personContactRepository;
            }

            public async Task<ResponseMessage<PersonDetailModel>> Handle(GetPersonDetailQuery request, CancellationToken cancellationToken)
            {
                PersonDetailModel model = new();

                var person = await _personRepository.GetAsync(s => s.Id == request.Id);
                model.Person = person;
                model.PersonContacts = await _personContactRepository.GetListAsync(s => s.PersonId == person.Id);

                return ResponseMessage<PersonDetailModel>.Success(model, 200);
            }
        }
    }
}
