using Movie.Entity;
using Movie.Response;
using MovieProject.Models;

namespace MovieProject.Response
{
    public class EvaluationResponse :EvaluationFatherResponse
    {
        public long UserIdFk { get; set; }
        public long MovieIdFk { get; set; }

        public static EvaluationResponse Map(EvaluationEntity evaluationEntity)
        {
            EvaluationResponse response = new EvaluationResponse
            {
                Id = evaluationEntity.Id,
                Nota = evaluationEntity.Note,
                Comentario = evaluationEntity.Comment,
                DataPostagem = DateTime.Now.ToString("dd/MM/yyyy HH'h':mm'm'"),
                UserIdFk = evaluationEntity.UserIdFk,
                MovieIdFk = evaluationEntity.MovieIdFk
            };
            return response;
        }
    }
}
