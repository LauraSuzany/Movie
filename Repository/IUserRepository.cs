using Movie.Entity;
using Movie.Models;

namespace Movie.Repository
{
    public interface IUserRepository
    {
        public object AddUser(UserEntity userEntity);
        public bool NicknameExist(string nickname);
        public UserEntity FindById(long id);

        public UserEntity FindByNickname(string nickname);
        public void DeleteById(long id);
    }
}
