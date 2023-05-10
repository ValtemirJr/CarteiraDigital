using DesafioCarteira.Models;
using DesafioCarteira.Repository;
using DesafioCarteira.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Controllers
{
    public class LoginController : Controller
    {
        private readonly PessoaRepository pessoaRepository;
        public LoginController(ISession session) => pessoaRepository = new PessoaRepository(session);

        public IActionResult Index()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            Pessoa pessoa = pessoaRepository.FindByEmail(login.Email);
            if (pessoa == null || pessoa.Senha != login.Senha)
            {
                ModelState.AddModelError("Email", "Usuário ou senha inválidos.");
                return View(login);
            }
            return RedirectToAction("AreaPessoal", "Pessoa", new { pessoaId = pessoa.PessoaId }); 
        }
    }
}
