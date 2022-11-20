using Microsoft.EntityFrameworkCore;
using Movie.Entity;

namespace Movie.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        {
            //Caso não exista o banco ou a tabela cria automaticamente 
            Database.EnsureCreated();
        }

        public DbSet<MovieEntity> Movie { get; set; }
        public DbSet<EvaluationEntity> Evaluation { get; set; }
        public DbSet<UserEntity> User { get; set; }
    }
}
