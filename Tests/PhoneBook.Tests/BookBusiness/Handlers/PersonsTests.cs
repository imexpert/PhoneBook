using FluentAssertions;
using Moq;
using NUnit.Framework;
using PhoneBook.Libraries.Book.Business.Handlers.Persons.Commands;
using PhoneBook.Libraries.Book.DataAccess.Abstract;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Tests.BookBusiness.Handlers
{
    using static CreatePersonCommand;

    [TestFixture]
    public class PersonsTests
    {
        private Mock<IPersonRepository> _personRepository;

        private CreatePersonCommandHandler _createPersonCommandHandler;

        [SetUp]
        public void Setup()
        {
            _personRepository = new Mock<IPersonRepository>();
            _createPersonCommandHandler = new CreatePersonCommandHandler(_personRepository.Object);
        }

        [Test]
        public void Handler_CreatePersonGroup()
        {
            var createPersonCommand = new CreatePersonCommand();
            Person person = new Person()
            {
                Company = "NEYE Tech A.Ş.",
                Firstname = "23423",
                Lastname = "ÜNAL"
            };

            createPersonCommand.Model = person;

            var result = _createPersonCommandHandler
                .Handle(createPersonCommand, new CancellationToken()).Result;
            result.IsSuccess.Should().BeTrue();
        }
    }
}
