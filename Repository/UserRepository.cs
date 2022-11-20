using Microsoft.EntityFrameworkCore;
using Movie.Context;
using Movie.Entity;
using Movie.Models;

namespace Movie.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Contexto _contexto;

        public UserRepository(Contexto context)
        {
            _contexto = context;
        }
        public object AddUser(UserEntity userEntity)
        {
            try
            {
                _contexto.Add(userEntity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }


            return userEntity;
        }

        /// <summary>
        /// Find nickname
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns>true or false</returns>
        public bool FindByNickname(string nickname)
        {
            DbSet<UserEntity> userEntity = _contexto.User;
            bool IsNamePresent = userEntity.Where(x => x.Nickname.Equals(nickname)).Select(x => x.Nickname.Equals(nickname)).FirstOrDefault();
            return IsNamePresent;
        }
    }
}
