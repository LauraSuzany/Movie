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
        /// List all users
        /// </summary>
        /// <returns>list of user</returns>
        public List<UserEntity> GetAllUser()
        {
            try
            {
                List<UserEntity> listUser = _contexto.User.ToList();
                return listUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }
        }

        /// <summary>
        /// Search user by ID
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns>The object of the movie</returns>
        public UserEntity FindById(long id)
        {
            try
            {
                /*.AsNoTracking() foi usado pois está dando um exceção de contexto, pois em alguns métodos são usados mais de um contexto
                 * de requisição ao banco ex: UpdateUser() usa findByid (que abre um contexto e isto é rastreado) e UpdateById que abre 
                 * outro contexto que também é rastreado, logo, como a injeção de dependência é uma singleton os contextos abertos geram 
                 * conflito logo o método AsNoTracking() não rastreia esse contexto porém ele pode ser usado apenas para requisições que não 
                 * fazem alteração no banco
                 */

                UserEntity? userEntity = _contexto.User.AsNoTracking().FirstOrDefault(x => x.Id == id);
                return userEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find nickname
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns>true or false</returns>
        public bool NicknameExist(string nickname)
        {
            DbSet<UserEntity> userEntity = _contexto.User;
            bool IsNamePresent = userEntity.Where(x => x.Nickname.Equals(nickname)).Select(x => x.Nickname.Equals(nickname)).FirstOrDefault();
            return IsNamePresent;
        }

        /// <summary>
        /// find user by nickname
        /// </summary>
        /// <param name="nickname">nickname user</param>
        /// <returns>the object by the nickname</returns>
        public UserEntity FindByNickname(string nickname)
        {
            DbSet<UserEntity> userEntity = _contexto.User;
            UserEntity? findNickname = userEntity.Where(x => x.Nickname.Equals(nickname)).FirstOrDefault();
            return findNickname;
        }

        public UserEntity UpdateById(UserEntity userEntity)
        {
            try
            {
                _contexto.User.Update(userEntity);
                _contexto.SaveChanges();
                return (userEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }

        }

        public void DeleteById(long id)
        {
            try
            {
                _contexto.User.Remove(FindById(id));
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
        }

    }
}
