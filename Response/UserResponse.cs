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

        public static UserResponse Map(UserModel userModel)
        {
            UserResponse response = new UserResponse
            {
                Nome = userModel.Nome,
                Apelido = userModel.Apelido,
                DataNascimento = DateTime.Parse(userModel.DataNascimento).ToString("dd/MM/yyyy"),
                Sexo = userModel.Sexo
            };
            return response;
        }
    }
}
