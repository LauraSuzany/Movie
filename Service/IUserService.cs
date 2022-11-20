using Movie.Entity;
using Movie.Models;

namespace Movie.Service
{
    public interface IUserService
    {
        public object AddUser(UserModel userModel);
        public object FindByID(long id);
        public object FindByFindByNickname(string findByNickname);
    }
}
