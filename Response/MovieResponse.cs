using Movie.Entity;

namespace Movie.Response
{
    public class MovieResponse
    {
        public long id { get; set; }
        public string titulo { get; set; }
        public string dataLancamento { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public string classificacao { get; set; }

        public static MovieResponse Map(MovieEntity movieEntity)
        {
            MovieResponse response = new MovieResponse
            {   
                id = movieEntity.Id,
                titulo = movieEntity.Title,
                dataLancamento = movieEntity.ReleaseDate.ToString("dd/MM/yyyy"),
                descricao = movieEntity.Description,
                categoria = movieEntity.Category,
                classificacao = movieEntity.Classification,
            };
            return response;
        }
    }
}

