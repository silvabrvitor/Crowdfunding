using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroSolicitacoes.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Solicitacao;Integrated Security=True");
            
        }
        public virtual DbSet<Curso> Curso { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }
    }
}
