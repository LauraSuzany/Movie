using Microsoft.EntityFrameworkCore;

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
    }
}
