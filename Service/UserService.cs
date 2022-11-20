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
            
            if (_userRepository.NicknameExist(userModel.Apelido))
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

        public object GetUsers()
        {
            List<UserEntity> listUsers = _userRepository.GetAllUser();
            if (listUsers.Count() == 0)
            {
                return $"Não há usuários para serem exibidos.";
            }
            List<UserResponse> userResponses = UserResponse.Map(listUsers);
            return userResponses;
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

        public object FindByFindByNickname(string findByNickname)
        {
           
            if (!_userRepository.NicknameExist(findByNickname))
            {
                return $"Não existe um usuário com esse nickname: '{findByNickname}'";
            }
            UserEntity findNickname = _userRepository.FindByNickname(findByNickname);
            UserResponse movieResponse = UserResponse.Map(findNickname);
            return movieResponse;
        }

        public string DeleteUser(long id)
        {
            UserEntity findUserbyId = _userRepository.FindById(id);
            if (findUserbyId == null)
            {
                return $"O usuário com id: {id} não existe!";
            }
            _userRepository.DeleteById(id);
            return $"O usuário foi deletado com sucesso!";
        }
    }
}
