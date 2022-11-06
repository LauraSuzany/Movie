using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie.Entity
{
    public class MovieModel
    {
        public string Nome { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string Classificacao { get; set; }
    }
}
