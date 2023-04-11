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
        public async Task<IActionResult> CriarMovimento(int pessoaId)
        {
            ViewBag.Nome = (_session.Get<Pessoa>(pessoaId)).Nome;
            ViewBag.Id = pessoaId;
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> CriarMovimento(MovimentoEntrada entrada, int pessoaId)
        {
            entrada.Pessoa = await _session.GetAsync<Pessoa>(pessoaId);

            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveAsync(entrada);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(CriarMovimento), new { pessoaId = pessoaId });
                }
            }
            return View(entrada);
        }
    }
}
