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
    public class MovimentoController : Controller
    {
        private readonly MovimentoRepository movimentoRepository;
        private readonly PessoaRepository pessoaRepository;

        public MovimentoController(ISession session) 
        {
            movimentoRepository = new MovimentoRepository(session);
            pessoaRepository = new PessoaRepository(session);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CriarMovimento(int pessoaId)
        {
            ViewBag.Id = pessoaId;
            Pessoa pessoa = await pessoaRepository.FindByID(pessoaId);
            ViewBag.Pessoa = pessoa;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarMovimento(MovimentoViewModel movimento, string valor)
        {
            IMovimento movimentoEscolhido = movimento.TipoMovimento ? new MovimentoEntrada() : new MovimentoSaida();
            movimentoEscolhido.Pessoa = await pessoaRepository.FindByID(movimento.PessoaId);
            movimentoEscolhido.Descricao = movimento.Descricao;
            movimentoEscolhido.Valor = Convert.ToDouble(valor.Replace('.', ','));
            ViewBag.Pessoa = movimentoEscolhido.Pessoa;
            


            bool permitido;

            if(movimentoEscolhido is MovimentoSaida)
            {
                permitido = await Saque(movimentoEscolhido.Pessoa, movimentoEscolhido.Valor);
            }
            else
            {
                permitido = await Deposito(movimentoEscolhido.Pessoa, movimentoEscolhido.Valor);
            }

            if (ModelState.IsValid && permitido)
            {
                await movimentoRepository.Add(movimentoEscolhido);
                return RedirectToAction(nameof(CriarMovimento), new { pessoaId = movimento.PessoaId });
            }
            TempData["MensagemErro"] = "Saldo insuficiente!";
            TempData["ValorInvalido"] = "Por favor, insira um valor maior que 0";
            TempData["TipoInvalido"] = "Escolha um tipo";
            return View(movimento);
        }

        public async Task<bool> Saque(Pessoa pessoa, double? valor)
        {
            if(valor > pessoa.Saldo + pessoa.Limite)
                return false;
            if (valor > pessoa.Saldo)
            {
                double? diferenca = valor - pessoa.Saldo;
                pessoa.Saldo = 0;
                if (diferenca <= pessoa.Limite)
                {
                    pessoa.Saldo -= diferenca;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                pessoa.Saldo -= valor.Value;
            }
            await pessoaRepository.Update(pessoa);
            return true;
        }

        public async Task<bool> Deposito(Pessoa pessoa, double? valor)
        {
            pessoa.Saldo = pessoa.Saldo + valor;
            await pessoaRepository.Update(pessoa);
            return true;
        }
    }
}
