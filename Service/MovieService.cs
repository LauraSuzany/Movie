using Microsoft.AspNetCore.Http;
using Movie.Entity;
using Movie.Repository;
using Movie.Response;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MovieService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public object AddMovie(MovieModel movieModel)
        {
            if (_moviesRepository.FindByName(movieModel.Nome))
            {
                return $"O titulo {movieModel.Nome} já existe!";
            }

            MovieEntity movieEntity = new MovieEntity() {
                Title = movieModel.Nome,
                ReleaseDate = DateTime.Parse(DateTime.Parse(movieModel.DataLancamento).ToString("dd/MM/yyyy")),
                Category = movieModel.Categoria,
                Classification = movieModel.Classificacao,
                Description = movieModel.Descricao
            };
             _moviesRepository.Add(movieEntity);
            MovieResponse movieResponse = MovieResponse.Map(movieEntity);
            return movieResponse;
        }

        public List<MovieEntity> GetMovies()
        {
            List<MovieEntity> movieEntities = _moviesRepository.GetAllMovies();
            return movieEntities;
        }

        public object FindByID(int id)
        {
            MovieEntity movieEntity = _moviesRepository.FindById(id);
            if (movieEntity == null)
            {
                return $"O ID {id} não existe!";
            }
            
            MovieResponse movieResponse = MovieResponse.Map(movieEntity);
            return movieResponse;
        }

        public object FindByName(string name)
        {
            IQueryable<MovieEntity> movieEntities = _moviesRepository.NameExist(name);
            if (movieEntities.Count() == 0)
            {
                return $"O titulo {name} não existe!";
            }
            return movieEntities;
        }

        public object UpdateMovie(int id, MovieModel movieModel)
        {
            MovieEntity findById = _moviesRepository.FindById(id);
            if (findById == null)
            {
                return $"O id {id} não existe!";
            }
            
            MovieEntity movieEntityUpdate = new MovieEntity()
            {   Id = id,
                Title = movieModel.Nome,
                ReleaseDate = DateTime.Parse(DateTime.Parse(movieModel.DataLancamento).ToString("dd/MM/yyyy")),
                Category = movieModel.Categoria,
                Classification = movieModel.Classificacao,
                Description = movieModel.Descricao
            };

            MovieEntity updatebyId = _moviesRepository.UpdateById(movieEntityUpdate);
            MovieResponse movieResponse = MovieResponse.Map(updatebyId);
            return movieResponse;
        }

        public string DeleteMovie(int id)
        {
            MovieEntity findById = _moviesRepository.FindById(id);
            if (findById == null)
            {
                return $"O id {id} não existe!";
            }
            _moviesRepository.DeleteByID(id);
            return $"O filme foi deletado com sucesso!";
        }

        public async Task<object> Upload(IFormFile cover, string name)
        {
            string path = "";
            try
            {
                if (cover.Length > 0)
                {
                    int posicaoCaracter = cover.FileName.IndexOf(".");
                    string newNameCover = name + cover.FileName.Substring(posicaoCaracter);
                    string extension = ".JPG, .GIF, .PNG, .SVG, .PSD, .WEBP, .RAW, .TIFF";
                    if (!extension.Contains(cover.FileName.Substring(posicaoCaracter).ToUpper()))
                    {
                        return $"Extenção inválida: {cover.FileName.Substring(posicaoCaracter)}";
                    }
                   
                    
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "PastaImg"));
                    if (File.Exists(Path.Combine(path, newNameCover)))
                    {
                        return $"O arquivo {newNameCover} já existe.";
                    }
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, newNameCover), FileMode.Create))
                    {
                        await cover.CopyToAsync(fileStream);
                    }
                    return new { Mensagem = "Imagem salva com Sucesso", Caminho = path, Nome = newNameCover };
                }
                else
                {
                    return "Não foi possível salvar imagem";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
