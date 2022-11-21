using Movie.Entity;
using MovieProject.Models;

namespace MovieProject.Repository
{
    public interface IEvaluationRepository
    {
        public object AddEvaluation(EvaluationEntity evaluationEntity);
        public List<EvaluationEntity> GetAllEvaluation();
        public EvaluationEntity UpdatelEvaluationById(EvaluationEntity evaluationEntity);
        public EvaluationEntity FindById(long id);
        public EvaluationEntity FindEvaluator(long userIdFk);
        public EvaluationEntity FindRatedMovie(long movieIdFk);
    }
}
