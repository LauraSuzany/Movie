using Movie.Entity;
using Movie.Models;

namespace Movie.Service
{
    public interface IUserService
    {
        public object AddUser(UserModel userModel);
        public object GetUsers();
        public object FindByID(long id);
        public object FindByFindByNickname(string findByNickname);
        public object UpdateUser(long id, UserModel userModel);
        public string DeleteUser(long id);

    }
}
