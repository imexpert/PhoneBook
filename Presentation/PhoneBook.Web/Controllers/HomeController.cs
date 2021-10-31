using Microsoft.AspNetCore.Mvc;
using PhoneBook.Libraries.Book.Entities.Concrete;
using PhoneBook.Web.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {
        IPersonService _personService;
        IPersonContactService _personContactService;

        public HomeController(
            IPersonService personService,
            IPersonContactService personContactService)
        {
            _personService = personService;
            _personContactService = personContactService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _personService.GetListAsync());
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            return View(await _personService.GetPersonDetailAsync(id));
        }

        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            var contactResult = await _personService.AddAsync(person);
            if (contactResult.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var result = await _personService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = result.Message;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateContact(Guid id)
        {
            PersonContact contact = new();
            contact.PersonId = id;
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(PersonContact contact)
        {
            var contactResult = await _personContactService.AddAsync(contact);
            if (contactResult.IsSuccess)
            {
                return RedirectToAction("Detail", "Home", new { id = contactResult.Data.PersonId });
            }

            return View(contact);
        }

        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var result = await _personContactService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Detail", "Home", new { id = result.Data.PersonId });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
