using Movie.Entity;
using Movie.Models;

namespace Movie.Repository
{
    public interface IUserRepository
    {
        public object AddUser(UserEntity userEntity);
        public bool FindByNickname(string nickname);
    }
}
