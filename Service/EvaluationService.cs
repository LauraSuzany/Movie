using Movie.Entity;
using Movie.Repository;
using Movie.Response;
using MovieProject.Models;
using MovieProject.Repository;
using MovieProject.Response;

namespace MovieProject.Service
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IUserRepository _userRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository, IMoviesRepository moviesRepository, IUserRepository userRepository)
        {
            this._evaluationRepository = evaluationRepository;
            this._moviesRepository = moviesRepository;
            this._userRepository = userRepository;
        }

        public object AddEvaluation(EvaluationModel evaluationModel)
        {
            MovieEntity movieEntity = _moviesRepository.FindById(evaluationModel.FilmeIdFk);
            if (movieEntity == null)
            {
                return $"O Filme com id '{evaluationModel.FilmeIdFk}' não existe!";
            }
            UserEntity userEntity = _userRepository.FindById(evaluationModel.UsuarioIdFk);
            if (userEntity == null)
            {
                return $"O usuário com id '{evaluationModel.UsuarioIdFk}' não existe!";
            }

            List<EvaluationEntity> listEvaluation = _evaluationRepository.GetAllEvaluation(); 
            if (listEvaluation.Exists(x => x.UserIdFk == evaluationModel.UsuarioIdFk && x.MovieIdFk == evaluationModel.FilmeIdFk))
            {
                return $"O usuário com id: '{evaluationModel.UsuarioIdFk}' já atribuiu um comentário para este filme!";
            }
            EvaluationEntity evaluationEntity = new EvaluationEntity()
            {
                 Note = evaluationModel.Nota,
                 Comment = evaluationModel.Comentario,
                 PostDate = DateTime.Now,
                 MovieIdFk = evaluationModel.FilmeIdFk,
                 UserIdFk = evaluationModel.UsuarioIdFk,
            };
            _evaluationRepository.AddEvaluation(evaluationEntity);
            EvaluationUserMovieResponse userResponse = EvaluationUserMovieResponse.Map(evaluationModel, movieEntity, userEntity);
            return userResponse;
        }

        public object UpdateEvaluation(long userId, long movieId ,EvaluationModel evaluationModel)
        {
            if (_evaluationRepository.GetAllEvaluation().Count() == 0)
            {
                return $"Não há avaliações.";
            }

            EvaluationEntity evaluator = _evaluationRepository.FindEvaluator(userId);
            if (evaluator == null)
            {
                return $"O usuário com id: '{userId}' não tem avaliações ou não existe!";
            }

            EvaluationEntity ratedMovie = _evaluationRepository.FindRatedMovie(movieId);
            if (ratedMovie == null)
            {
                return $"O Filme com id: '{movieId}' não tem avaliações ou não existe!!";
            }

            EvaluationEntity? evaluation = _evaluationRepository.GetAllEvaluation().Where(x => x.UserIdFk == userId && x.MovieIdFk == movieId).FirstOrDefault();
            EvaluationEntity evaluationEntity = new EvaluationEntity()
            {   
                Id = evaluation.Id,
                Note = evaluationModel.Nota,
                Comment = evaluationModel.Comentario,
                PostDate = DateTime.Now,
                UserIdFk = userId, 
                MovieIdFk = movieId
            };

            _evaluationRepository.UpdatelEvaluationById(evaluationEntity);
            EvaluationResponse evaluationResponse = EvaluationResponse.Map(evaluationEntity);
            return evaluationResponse;
        }

        public object findEvaluationById(long id)
        {
            EvaluationEntity objectEvaluation = _evaluationRepository.FindById(id);
            if(objectEvaluation == null)
            {
                return $"A avaliação com id: '{id}' não existe!";
            }

            EvaluationResponse evaluationResponse = EvaluationResponse.Map(objectEvaluation);
            return evaluationResponse;
        }
    }
}
