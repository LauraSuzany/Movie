using Movie.Entity;
using Movie.Models;

namespace Movie.Service
{
    public interface IUserService
    {
        public object AddUser(UserModel userModel);
    }
}
