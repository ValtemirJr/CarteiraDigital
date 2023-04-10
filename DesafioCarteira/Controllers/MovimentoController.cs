using DesafioCarteira.Models;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Controllers
{
    public class MovimentoController : Controller
    {
        private readonly ISession _session;

        public MovimentoController(ISession session)
        {
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NovoMovimento(int pessoaId)
        {
            return View(await _session.GetAsync<Pessoa>(pessoaId));
        }

        [HttpPost]
        public async Task<IActionResult> NovoMovimento(MovimentoEntrada entrada)
        {
            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveAsync(entrada);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(NovoMovimento));
                }
            }
            return View(entrada);
        }
    }
}
