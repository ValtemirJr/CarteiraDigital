using DesafioCarteira.Models;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ISession _session;

        public PessoaController(ISession session)
        {
            _session = session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            IList<Pessoa> pessoas = _session.QueryOver<Pessoa>().List();

            return View(pessoas);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveAsync(pessoa);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(Lista));
                }
            }
            return View(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> Extrato(int pessoaId)
        {
            Pessoa pessoa = await _session.GetAsync<Pessoa>(pessoaId);

            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int pessoaId)
        {
            var pessoa = await _session.GetAsync<Pessoa>(pessoaId);
            using(ITransaction transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(pessoa);
                await transaction.CommitAsync();
                return RedirectToAction(nameof(Lista));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int pessoaId)
        {
            return View(await _session.GetAsync<Pessoa>(pessoaId));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int pessoaId, Pessoa pessoa)
        {
            if(pessoaId != pessoa.PessoaId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                using(ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveOrUpdateAsync(pessoa);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(Lista));
                }
            }
            return View(pessoa);
        }
    }
}
