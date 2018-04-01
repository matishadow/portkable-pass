using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPasswordGenerator passwordGenerator;

        public HomeController(IPasswordGenerator passwordGenerator)
        {
            this.passwordGenerator = passwordGenerator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GeneratePassword(string masterPassword, string domainName, int length,
            CharacterSpace characterSpace, HmacGenerator hmacGenerator)
        {
            return passwordGenerator.GeneratePassword(domainName, masterPassword, length, 
                hmacGenerator, characterSpace);
        }
    }
}