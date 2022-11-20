using Movie.Entity;
using Movie.Models;
using Movie.Repository;
using Movie.Response;
using MovieProject.Response;

namespace Movie.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public object AddUser(UserModel userModel)
        {   
            
            if (_userRepository.FindByNickname(userModel.Apelido))
            {
                return $"O apelindo '{userModel.Apelido}' já está em uso";
            }
            if (!(userModel.Sexo.Equals('f') || userModel.Sexo.Equals('m')))
            {
               return $"Sexo '{userModel.Sexo}' invalido, digite 'f' para feminino ou 'm' para masculido";
            }

            UserEntity userEntity = new UserEntity()
            {
                Name = userModel.Nome,
                Nickname = userModel.Apelido,
                Birth_Date = DateTime.Parse(DateTime.Parse(userModel.DataNascimento).ToString("dd/MM/yyyy")),
                Sex = userModel.Sexo,
            };
            _userRepository.AddUser(userEntity);
            UserResponse userResponse = UserResponse.Map(userEntity);
            return userResponse;
        }

        public object FindByID(long id)
        {
            UserEntity userEntity = _userRepository.FindById(id);
            if (userEntity == null)
            {
                return $"Não existe um usuário com esse: {id}!";
            }
            UserResponse movieResponse = UserResponse.Map(userEntity);
            return movieResponse;
        }


    }
}
