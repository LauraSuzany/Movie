using Movie.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }
        
        public string DataNascimento { get; set; }

        public char Sexo { get; set; }

    }
}
