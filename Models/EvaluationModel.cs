using Movie.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Models
{
    public class EvaluationModel
    {
        
        public long Id { get; set; }

        public double Nota { get; set; }

        public string? Comentario { get; set; }

        public long FilmeIdFk { get; set; }

        public long UsuarioIdFk { get; set; }

    }
}
