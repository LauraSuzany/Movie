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

        public static List<UserResponse> Map(List<UserEntity> listUser)
        {
            List<UserResponse> listUserResponses = new List<UserResponse>();
            listUser.ForEach(x => 
            { 
                listUserResponses.Add(
                    new UserResponse { 
                        Nome = x.Name,
                        Apelido = x.Nickname,
                        DataNascimento =x.Birth_Date.ToString("dd/MM/yyyy"),
                        Sexo = x.Sex

                    }); 
            });      
            
            return listUserResponses;
        }
    }
}