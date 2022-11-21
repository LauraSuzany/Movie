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
            EvaluationResponse userResponse = EvaluationResponse.Map(evaluationModel, movieEntity, userEntity);
            return userResponse;
        }

        public object UpdateEvaluation(long id, EvaluationModel evaluationModel)
        {
            if (_evaluationRepository.GetAllEvaluation().Count() == 0)
            {
                return $"Não há avaliações para serem exibidas.";
            }

            EvaluationEntity findById = _evaluationRepository.FindById(id);
            if (findById == null)
            {
                return $"A avaliação com m id: '{id}' não existe!";
            }

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

            //List<EvaluationEntity> listEvaluation = _evaluationRepository.GetAllEvaluation();
            //if (listEvaluation.Exists(x => x.UserIdFk == evaluationModel.UsuarioIdFk && x.MovieIdFk == evaluationModel.FilmeIdFk))
            //{
            //    return $"O usuário com id: '{evaluationModel.UsuarioIdFk}' já atribuiu um comentário para este filme!";
            //}

            EvaluationEntity evaluationEntity = new EvaluationEntity()
            {
                Id = id,
                Note = evaluationModel.Nota,
                Comment = evaluationModel.Comentario,
                PostDate = DateTime.Now,
                MovieIdFk = evaluationModel.FilmeIdFk,
                UserIdFk = evaluationModel.UsuarioIdFk
            };
            _evaluationRepository.UpdatelEvaluationById(evaluationEntity);
            EvaluationResponse evaluationResponse = EvaluationResponse.Map(evaluationModel, movieEntity, userEntity);
            return evaluationResponse;
        }
    }
}
