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
        public string DeleteUser(long id);

    }
}
