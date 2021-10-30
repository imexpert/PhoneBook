using FluentValidation;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Validators
{
    public class PersonCreateValidator : AbstractValidator<Person>
    {
        public PersonCreateValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("İsim alanı boş olamaz");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Soyadı alanı boş olamaz");
            RuleFor(x => x.Company).NotEmpty().WithMessage("Firma alanı boş olamaz");
        }
    }
}
