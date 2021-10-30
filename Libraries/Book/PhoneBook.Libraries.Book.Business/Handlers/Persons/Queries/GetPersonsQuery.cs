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
    public class GetPersonsQuery : IRequest<ResponseMessage<IEnumerable<Person>>>
    {
        public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, ResponseMessage<IEnumerable<Person>>>
        {
            private readonly IPersonRepository _personRepository;

            public GetPersonsQueryHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            public async Task<ResponseMessage<IEnumerable<Person>>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
            {
                var personList = await _personRepository.GetListAsync();

                return ResponseMessage<IEnumerable<Person>>.Success(personList, 200);
            }
        }
    }
}
