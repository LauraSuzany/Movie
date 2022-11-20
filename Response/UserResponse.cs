using Movie.Entity;
using Movie.Models;
using Movie.Response;

namespace MovieProject.Response
{
    public class UserResponse
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string DataNascimento { get; set; }
        public char Sexo { get; set; }

        public static UserResponse Map(UserEntity userEntity)
        {
            UserResponse response = new UserResponse
            {
                Nome = userEntity.Name,
                Apelido = userEntity.Nickname,
                DataNascimento = userEntity.Birth_Date.ToString("dd/MM/yyyy"),
                Sexo = userEntity.Sex
            };
            return response;
        }
    }
}