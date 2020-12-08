using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institute.Models;
using Microsoft.EntityFrameworkCore;

namespace Institute.Repository
{
    public class PessoasRepository
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private BancoDeDados BancoDeDados;

        public PessoasRepository(BancoDeDados db) {
            BancoDeDados = db;
        }
            public void Adicionar(Pessoa pessoa)
        {
            BancoDeDados.Pessoas.Add(pessoa);
            BancoDeDados.SaveChanges();
            // pessoas.Add(pessoa);
        }

        public void Deletar(Pessoa pessoa)
        {
            BancoDeDados.Pessoas.Remove(pessoa);
            BancoDeDados.SaveChanges();
            // pessoas.Remove(pessoa);
        }

        public List<Pessoa> BuscarPessoa(string busca)
        {
            if (busca != null)
            {
                return BancoDeDados.Pessoas.Where(pessoa => pessoa.Nome.Contains(busca)).ToList();
                // return pessoas.Where(pessoa => pessoa.Nome.Contains(busca)).ToList();
            }
            return BancoDeDados.Pessoas.ToList();
            // return pessoas;
        }

        public Pessoa BuscarPessoaPelaMatricula(int matricula)
        {
            return BancoDeDados.Pessoas.First(pessoa => pessoa.Matricula == matricula);
            // return pessoas.First(pessoa => pessoa.Matricula == matricula);
        }

        public void Alterar(Pessoa pessoa)
        {
            BancoDeDados.Pessoas.Update(pessoa);
            BancoDeDados.SaveChanges();
            // Pessoa pessoaAlterado = BuscarPessoaPelaMatricula(pessoa.Matricula);
            // pessoas.Remove(pessoaAlterado);

            // Adicionar(pessoa);
        }

        public List<Pessoa> buscarAniversariantes(List<Pessoa> pessoas)
        {

            //return BancoDeDados.Pessoas.Where(pessoa => pessoa.Data.Date.Equals(DateTime.Now.Date)).ToList();
            return pessoas.Where(pessoa => pessoa.Data.Date.Equals(DateTime.Now.Date)).ToList();
        }


    }
}


