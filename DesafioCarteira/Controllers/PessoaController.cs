using DesafioCarteira.Enumerables;
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
    public class PessoaController : Controller
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _contxt;
        private readonly PessoaRepository pessoaRepository;
        public PessoaController(ISession session, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) 
        { 
            pessoaRepository = new PessoaRepository(session);
            _contxt = httpContextAccessor;
        }

        
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
        public async Task<IActionResult> GeraExtrato(int pessoaId)
        {
            Pessoa pessoa = await pessoaRepository.FindByID(pessoaId);
            GeraExtratoViewModel extratoView = new GeraExtratoViewModel();
            extratoView.Extrato = Merge(pessoa.Entradas, pessoa.Saidas);
            extratoView.PessoaId = pessoaId;
            ViewBag.Nome = pessoa.Nome;
            ViewBag.Saldo = 0;
            return View(extratoView);
        }

        [HttpPost]
        public async Task<IActionResult> GeraExtrato(string opcao, DateTime? dataInicio, DateTime? dataFim, int pessoaid, string tipo_mov)
        {
            Pessoa pessoa = await pessoaRepository.FindByID(pessoaid);
            GeraExtratoViewModel dadosFiltro = new GeraExtratoViewModel();
            dadosFiltro.PessoaId = pessoaid;
            dadosFiltro.DataInicio = dataInicio;
            dadosFiltro.DataFim = dataFim;
            dadosFiltro.OpcaoDiasExtrato = (EnumFiltroExtrato)Enum.Parse(typeof(EnumFiltroExtrato), opcao);
            dadosFiltro.Extrato = Merge(pessoa.Entradas, pessoa.Saidas); //Junta TODAS entradas e saidas de um cliente
            IList<Object> extratoCompleto = dadosFiltro.Extrato; //Armazena o extrato completo da pessoa
            dadosFiltro.Extrato = FiltrarExtrato(dadosFiltro, tipo_mov); //Filtra entradas e saidas para um periodo pedido pelo cliente
            if (tipo_mov == "0")
            {
                ViewBag.Saldo = CalculaSaldoAnterior(extratoCompleto, dadosFiltro.Extrato);
                TempData["TagSaldoAnteior"] = true;
            }
            else
            {
                ViewBag.Saldo = 0;
            }
            ViewBag.Nome = pessoa.Nome;
            return View("GeraExtrato", dadosFiltro);
        }

        public double? CalculaSaldoAnterior(IList<Object> extratoCompleto, IList<Object> extratoFiltrado)
        {
            double? saldoAnterior = SomaMovimentos(extratoCompleto) - SomaMovimentos(extratoFiltrado);
            return saldoAnterior;
        }

        public IList<Object> FiltrarExtrato(GeraExtratoViewModel filtro, string tipo_mov)
        {
            IList<Object> extratoFiltrado = new List<Object>();
            if (filtro.Extrato == null)
                return filtro.Extrato;

            DateTime? diaComeco = filtro.OpcaoDiasExtrato switch
            {
                EnumFiltroExtrato.Personalizado => filtro.DataInicio,
                EnumFiltroExtrato.UltimosSeteDias => DateTime.Now.AddDays(-7),
                EnumFiltroExtrato.UltimosQuinzeDias => DateTime.Now.AddDays(-15),
                _ => DateTime.Now.AddDays(-30)
            };

            DateTime? diaFinal = filtro.OpcaoDiasExtrato == EnumFiltroExtrato.Personalizado
                ? filtro.DataFim.Value.AddDays(1)
                : DateTime.Now;

            foreach (var movimento in filtro.Extrato)
            {
                if (movimento is MovimentoEntrada && ((MovimentoEntrada)movimento).DataEntrada >= diaComeco && ((MovimentoEntrada)movimento).DataEntrada <= diaFinal && (tipo_mov == "0" || tipo_mov == "1"))
                {
                    extratoFiltrado.Add(movimento);
                }
                else if (movimento is MovimentoSaida && ((MovimentoSaida)movimento).DataSaida >= diaComeco && ((MovimentoSaida)movimento).DataSaida <= diaFinal && (tipo_mov == "0" || tipo_mov == "2"))
                {
                    extratoFiltrado.Add(movimento);
                }
            }
            return extratoFiltrado;
         }

        public double? SomaMovimentos(IList<Object> extrato)
        {
            double? saldo = 0;

            foreach (var obj in extrato)
            {
                if (obj is MovimentoEntrada entrada)
                {
                    saldo += entrada.Valor;
                }
                else if (obj is MovimentoSaida saida)
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

        [HttpGet]
        public async Task<IActionResult> AreaPessoal(int pessoaId)
        {
            Pessoa pessoa = await pessoaRepository.FindByID(pessoaId);
            if (pessoa.Nome == "Admin")
                return View("AreaPessoalAdmin", pessoa);
            return View(pessoa);
        }
    }
}
