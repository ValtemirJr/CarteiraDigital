using DesafioCarteira.Models;
using DesafioCarteira.Repository;
using DesafioCarteira.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesafioCarteira.Controllers
{
    public class LoginController : Controller
    {
        private readonly PessoaRepository pessoaRepository;
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _contxt;
        public LoginController(NHibernate.ISession session, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            pessoaRepository = new PessoaRepository(session);
            _contxt = httpContextAccessor;
        }

        public IActionResult Index()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            Pessoa pessoa = pessoaRepository.FindByEmail(login.Email);
            pessoa.Entradas = null;
            pessoa.Saidas = null;
            if (pessoa == null || pessoa.Senha != login.Senha)
            {
                ModelState.AddModelError("Email", "Usuário ou senha inválidos.");
                return View(login);
            }
            string jsonString = JsonSerializer.Serialize(pessoa);
            _contxt.HttpContext.Session.SetString("User", jsonString);
            return RedirectToAction("AreaPessoal", "Pessoa", new { pessoaId = pessoa.PessoaId }); 
        }

        public IActionResult Logout()
        {
            _contxt.HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Login");
        }
    }
}
