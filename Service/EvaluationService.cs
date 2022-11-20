using Movie.Entity;
using Movie.Models;
using Movie.Repository;
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
            EvaluationEntity evaluationEntity = new EvaluationEntity()
            {
                 Note = evaluationModel.Nota,
                 Comment = evaluationModel.Comentario,
                 MovieIdFk = evaluationModel.FilmeIdFk,
                 UserIdFk = evaluationModel.UsuarioIdFk,
            };
            _evaluationRepository.AddEvaluation(evaluationEntity);
            EvaluationResponse userResponse = EvaluationResponse.Map(evaluationModel);
            return userResponse;
        }
    }
}
