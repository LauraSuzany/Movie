using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    [Table("Filme")]
    public class MovieModel
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Ano")]
        [Column("Ano")]
        public int Ano { get; set; }

        [Display(Name = "Descricao")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Categoria")]
        [Column("Categoria")]
        public string Categoria { get; set; }

        [Display(Name = "Classificacao")]
        [Column("Classificacao")]
        public string Classificacao { get; set; }
    }
}
