using MediatR;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.DataAccess.Abstract;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Business.Handlers.Persons.Queries
{
    public class GetPersonQuery : IRequest<ResponseMessage<Person>>
    {
        public Guid Id { get; set; }

        public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, ResponseMessage<Person>>
        {
            private readonly IPersonRepository _personRepository;

            public GetPersonQueryHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            public async Task<ResponseMessage<Person>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.GetAsync(x => x.Id == request.Id);

                return ResponseMessage<Person>.Success(person, 200);
            }
        }
    }
}
