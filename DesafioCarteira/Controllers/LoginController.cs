using DesafioCarteira.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                return View(login);
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
    }
}
