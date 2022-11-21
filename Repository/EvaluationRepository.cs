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
        /// <summary>
        /// Find evaluation by id
        /// </summary>
        /// <param name="id"> id evaluation</param>
        /// <returns>evaluation</returns>
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

        /// <summary>
        /// Find evaluator
        /// </summary>
        /// <param name="userIdFk">user id </param>
        /// <returns>the user that make the evaluation</returns>
        public EvaluationEntity FindEvaluator(long userIdFk)
        {
            EvaluationEntity? evaluator = _contexto.Evaluation.AsNoTracking().Where(x => x.UserIdFk == userIdFk).FirstOrDefault();
            return evaluator;
        }

        /// <summary>
        /// Get Movie evaluation by user
        /// </summary>
        /// <param name="movieIdFk">movie id</param>
        /// <returns>Rated movie</returns>
        public EvaluationEntity FindRatedMovie(long movieIdFk)
        {
            EvaluationEntity? ratedMovie = _contexto.Evaluation.AsNoTracking().Where(x => x.MovieIdFk == movieIdFk).FirstOrDefault();
            return ratedMovie;
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
