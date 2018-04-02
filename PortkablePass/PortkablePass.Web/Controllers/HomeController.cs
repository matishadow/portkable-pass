using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Encoding;
using PortkablePass.Web.Models;

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
        public ActionResult GeneratePassword(PasswordGeneration passwordGeneration)
        {
            var generatedPassword = new GeneratedPassword
            {
                Value = passwordGenerator.GeneratePassword(passwordGeneration.DomainName,
                    passwordGeneration.MasterPassword, passwordGeneration.PasswordLength,
                    passwordGeneration.HashFunction, passwordGeneration.CharacterSpace)
            };

            return Json(generatedPassword);
        }
    }
}