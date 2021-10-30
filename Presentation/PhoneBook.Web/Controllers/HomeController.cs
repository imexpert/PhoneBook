using Microsoft.AspNetCore.Mvc;
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

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
