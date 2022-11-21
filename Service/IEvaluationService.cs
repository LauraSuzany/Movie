using MovieProject.Models;

namespace MovieProject.Service
{
    public interface IEvaluationService
    {
        public object AddEvaluation(EvaluationModel evaluationModel);
        public object UpdateEvaluation(long id, EvaluationModel evaluationModel);
        public object findEvaluationById(long id);
    }
}
