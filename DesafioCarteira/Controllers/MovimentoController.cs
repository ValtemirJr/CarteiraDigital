﻿using DesafioCarteira.Models;
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
            ViewBag.Nome = pessoa.Nome;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarMovimento(MovimentoViewModel movimento)
        {
            IMovimento movimentoEscolhido = movimento.TipoMovimento ? new MovimentoEntrada() : new MovimentoSaida();
            movimentoEscolhido.Pessoa = await pessoaRepository.FindByID(movimento.PessoaId);
            movimentoEscolhido.Descricao = movimento.Descricao;
            movimentoEscolhido.Valor = movimento.Valor;

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
            return View(movimento);
        }

        public async Task<bool> Saque(Pessoa pessoa, double? valor)
        {
            if(valor > pessoa.Saldo)
                return false;
            pessoa.Saldo = pessoa.Saldo - valor;
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
