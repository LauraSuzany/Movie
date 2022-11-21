using Movie.Entity;
using Movie.Response;
using MovieProject.Models;

namespace MovieProject.Response
{
    public class EvaluationResponse
    {
        public MovieResponse Movie { get; set; }

        public long Id { get; set; }

        public double Nota { get; set; }

        public string? Comentario { get; set; }

        public string DataPostagem { get; set; }

        public UserResponse User { get; set; }

        public static EvaluationResponse Map(EvaluationModel evaluationModel, MovieEntity movieEntity, UserEntity userEntity)
        {
            EvaluationResponse response = new EvaluationResponse
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