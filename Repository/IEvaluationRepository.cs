using Movie.Entity;
using MovieProject.Models;

namespace MovieProject.Repository
{
    public interface IEvaluationRepository
    {
        public object AddEvaluation(EvaluationEntity evaluationEntity);
    }
}
