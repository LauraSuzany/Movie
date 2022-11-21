using Microsoft.EntityFrameworkCore;
using Movie.Context;
using Movie.Entity;
using MovieProject.Models;

namespace MovieProject.Repository
{
    public class EvaluationRepository :IEvaluationRepository
    {
        private readonly Contexto _contexto;

        public EvaluationRepository(Contexto context)
        {
            _contexto = context;
        }

        /// <summary>
        ///  Add evaluation of a user by movie
        /// </summary>
        /// <param name="evaluationModel"> model evaluation</param>
        public object AddEvaluation(EvaluationEntity evaluationEntity)
        {
            try
            {
                _contexto.Add(evaluationEntity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }

            return evaluationEntity;
        }

        /// <summary>
        /// Get all evaluation
        /// </summary>
        /// <returns>list evaluation</returns>
        public List<EvaluationEntity> GetAllEvaluation()
        {
            try
            {
                List<EvaluationEntity> listEvaluation = _contexto.Evaluation.AsNoTracking().ToList();
                return listEvaluation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EvaluationEntity FindById(long id)
        {
            try
            {
                EvaluationEntity? findEvaluationById = _contexto.Evaluation.AsNoTracking().FirstOrDefault(x => x.Id == id);
                return findEvaluationById;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EvaluationEntity UpdatelEvaluationById(EvaluationEntity evaluationEntity)
        {
            try
            {
                _contexto.Evaluation.Update(evaluationEntity);
                _contexto.SaveChanges();
                return (evaluationEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }

        }
    }
}
