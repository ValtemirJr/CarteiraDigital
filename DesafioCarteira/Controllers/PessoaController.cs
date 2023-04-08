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
            IList<Object> extrato = Merge(pessoa.Entradas, pessoa.Saidas);
            ViewBag.NomePessoa = pessoa.Nome;
            return View(extrato);
        }

        public static IList<Object> Merge(IList<MovimentoEntrada> entradas, IList<MovimentoSaida> saidas)
        {
            IList<Object> extrato = new List<Object>();

            if (entradas.Count == 0)
            {
                return saidas.Select(x => (Object)x).ToList();
            }
            if (saidas.Count == 0)
            {
                return entradas.Select(x => (Object)x).ToList();
            }

            int i = 0, j = 0;

            while (i < entradas.Count && j < saidas.Count)
            {
                if (entradas[i].DataEntrada > saidas[j].DataSaida)
                {
                    extrato.Add(entradas[i]);
                    i++;
                }
                else
                {
                    extrato.Add(saidas[j]);
                    j++;
                }
            }

            while (i < entradas.Count)
            {
                extrato.Add(entradas[i]);
                i++;
            }

            while (j < saidas.Count)
            {
                extrato.Add(saidas[j]);
                j++;
            }

            return extrato;
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
