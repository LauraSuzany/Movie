using Movie.Entity;

namespace Movie.Response
{
    public class MovieResponse
    {
        public string titulo { get; set; }
        public string dataLancamento { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public string classificacao { get; set; }

        public static MovieResponse Map(MovieModel model)
        {
            MovieResponse response = new MovieResponse
            {
                titulo = model.Nome,
                dataLancamento = model.DataLancamento,
                descricao = model.Descricao,
                categoria = model.Categoria,
                classificacao = model.Classificacao,
            };
            return response;
        }
    }
}
