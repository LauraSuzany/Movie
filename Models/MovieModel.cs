using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie.Entity
{
    public class MovieModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string DataLancamento { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string Classificacao { get; set; }

    }
}
