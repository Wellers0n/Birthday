using Institute.Models;
using Microsoft.EntityFrameworkCore;

namespace Institute.Repository
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }

}