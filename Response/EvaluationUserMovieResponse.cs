using Movie.Entity;
using Movie.Response;
using MovieProject.Models;

namespace MovieProject.Response
{
    public class EvaluationUserMovieResponse : EvaluationFatherResponse
    {
        public MovieResponse Movie { get; set; }
        public UserResponse User { get; set; }

        public static EvaluationUserMovieResponse Map(EvaluationModel evaluationModel, MovieEntity movieEntity, UserEntity userEntity)
        {
            EvaluationUserMovieResponse response = new EvaluationUserMovieResponse
            {   
                Id = evaluationModel.Id,
                Nota = evaluationModel.Nota,
                Comentario = evaluationModel.Comentario,
                DataPostagem = DateTime.Now.ToString("dd/MM/yyyy HH'h':mm'm'"),
                Movie = new MovieResponse { 
                    id = movieEntity.Id,
                    titulo = movieEntity.Title, 
                    dataLancamento = movieEntity.ReleaseDate.ToString("dd/MM/yyyy"),
                    descricao = movieEntity.Description,
                    categoria = movieEntity.Category,
                    classificacao = movieEntity.Classification
                },
                User = new UserResponse { 
                    id = userEntity.Id,
                    Nome = userEntity.Name, 
                    Apelido = userEntity.Nickname, 
                    DataNascimento = userEntity.Birth_Date.ToString("dd/MM/yyyy"), 
                    Sexo = userEntity.Sex 
                }
            };
            return response;
        }
    }
}