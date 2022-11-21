using Movie.Entity;
using Movie.Response;

namespace MovieProject.Response
{
    public class EvaluationResponse : EvaluationResponseFather
    {
        public long IdMovieFk { get; set; }
        public long IduserFk { get; set; }
        public static EvaluationResponse Map(EvaluationEntity evaluationEntity)
        {
            EvaluationResponse response = new EvaluationResponse
            {
                Id = evaluationEntity.Id,
                Nota = evaluationEntity.Note,
                Comentario = evaluationEntity.Comment,
                DataPostagem = DateTime.Now.ToString("dd/MM/yyyy HH'h':mm'm'"),
                IdMovieFk = evaluationEntity.MovieIdFk,
                IduserFk = evaluationEntity.UserIdFk
            };
            return response;
        }
    }
}
