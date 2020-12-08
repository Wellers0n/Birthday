using System;
using System.ComponentModel.DataAnnotations;

namespace Institute.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int Matricula { get; set;}
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}


