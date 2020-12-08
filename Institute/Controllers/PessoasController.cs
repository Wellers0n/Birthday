using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Institute.Models;
using Institute.Repository;

namespace Pessoas.Controllers
{
    public class PessoasController : Controller
    {
        // private BancoDeDados BancoDeDados;
        PessoasRepository repository;
        public PessoasController(BancoDeDados db)
        {
            repository = new PessoasRepository(db);
        }
        // private readonly ILogger<PessoasController> _logger;

        /*public PessoasController(ILogger<PessoasController> logger)
        {
            _logger = logger;
        } */

        public IActionResult Lista(string busca)
        {
            //PessoasRepository repository = new PessoasRepository(BancoDeDados);
            List<Pessoa> pessoas = repository.BuscarPessoa(busca);
            List<Pessoa> pessoasOrdenadasPorData = pessoas.OrderBy(pessoa => pessoa.Data).ToList();
            return View(pessoasOrdenadasPorData);
        }

        public IActionResult Aniversariantes(string busca)
        {
            //PessoasRepository repository = new PessoasRepository(BancoDeDados);
            List<Pessoa> pessoas = repository.BuscarPessoa(busca);
            List<Pessoa> aniversariantes = repository.buscarAniversariantes(pessoas);

            return View(aniversariantes);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(int matricula, string nome, string data)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Matricula = matricula;
            pessoa.Nome = nome;
            pessoa.Data = DateTime.Parse(data);

            //PessoasRepository pessoasRepository = new PessoasRepository(BancoDeDados);

            repository.Adicionar(pessoa);

            return View();

        }
        [HttpGet]
        public IActionResult Deletar(int matricula)
        {
            //PessoasRepository repository = new PessoasRepository(BancoDeDados);
            Pessoa pessoa = repository.BuscarPessoaPelaMatricula(matricula);

            return View(pessoa);
        }
        [HttpPost]
        public IActionResult confirmarDeletar(int matricula)
        {
            //PessoasRepository repository = new PessoasRepository(BancoDeDados);
            Pessoa pessoa = repository.BuscarPessoaPelaMatricula(matricula);
            repository.Deletar(pessoa);

            return RedirectToAction("Lista");
        }
        [HttpGet]
        public IActionResult Editar(int matricula)
        {
            // PessoasRepository repository = new PessoasRepository(BancoDeDados);
            Pessoa pessoa = repository.BuscarPessoaPelaMatricula(matricula);

            return View(pessoa);
        }
        [HttpPost]
        public IActionResult Editar(int matricula, string nome)
        {
            // PessoasRepository repository = new PessoasRepository(BancoDeDados);
            Pessoa pessoa = repository.BuscarPessoaPelaMatricula(matricula);
            pessoa.Nome = nome;
            repository.Alterar(pessoa);
            return View(pessoa);
        }
        public IActionResult Detalhes(int matricula)
        {
            // PessoasRepository repository = new PessoasRepository(BancoDeDados);
            Pessoa pessoa = repository.BuscarPessoaPelaMatricula(matricula);
            return View(pessoa);
        }

        public IActionResult Pessoas()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
