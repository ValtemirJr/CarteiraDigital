using DesafioCarteira.Models;
using DesafioCarteira.Repository;
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
        private readonly PessoaRepository pessoaRepository;
        public PessoaController(ISession session) => pessoaRepository = new PessoaRepository(session);

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            IList<Pessoa> pessoas = pessoaRepository.FindAll().OrderBy(p => p.Nome).ToList();
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
                await pessoaRepository.Add(pessoa);
                return RedirectToAction(nameof(Lista));              
            }
            return View(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> Extrato(int pessoaId)
        {
            Pessoa pessoa = await pessoaRepository.FindByID(pessoaId);
            IList<Object> extrato = Merge(pessoa.Entradas, pessoa.Saidas);
            ViewBag.NomePessoa = pessoa.Nome;
            ViewBag.SaldoAnterior = 0;
            ViewBag.SaldoFinal = SomaMovimentos(pessoa);
            return View(extrato);
        }

        public async Task<IActionResult> FiltroExtrato()
        {
            return View("Extrato");
        }

        public double? SomaMovimentos(Pessoa pessoa)
        {
            double? saldo = 0;
            if (pessoa.Entradas != null)
            {
                foreach (MovimentoEntrada entrada in pessoa.Entradas)
                {
                    saldo += entrada.Valor;
                }
            }
            if (pessoa.Saidas != null)
            {
                foreach (MovimentoSaida saida in pessoa.Saidas)
                {
                    saldo -= saida.Valor;
                }
            }
            return saldo;
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
                if (entradas[i].DataEntrada < saidas[j].DataSaida)
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
            await pessoaRepository.Remove(pessoaId);
            return RedirectToAction(nameof(Lista));          
        }

        [HttpGet]
        public async Task<IActionResult> Update(int pessoaId)
        {
            Pessoa pessoa = await pessoaRepository.FindByID(pessoaId);
            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await pessoaRepository.Update(pessoa);
                return RedirectToAction(nameof(Lista));                
            }
            return View(pessoa);
        }
    }
}
