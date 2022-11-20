using Movie.Entity;
using Movie.Models;
using Movie.Response;
using MovieProject.Models;
using MovieProject.Response;

namespace MovieProject.Response
{
    public class EvaluationResponse
    {
        public long Id { get; set; }

        public double Nota { get; set; }

        public string? Comentario { get; set; }

        public string DataPostagem { get; set; }

        public long FilmeIdFk { get; set; }

        public long UsuarioIdFk { get; set; }

        public static EvaluationResponse Map(EvaluationModel evaluationModel)
        {
            EvaluationResponse response = new EvaluationResponse
            {
                Nota = evaluationModel.Nota,
                Comentario = evaluationModel.Comentario,
                DataPostagem = DateTime.Parse(evaluationModel.DataPostagem).ToString("dd/MM/yyyy"),
                FilmeIdFk = evaluationModel.FilmeIdFk,
                UsuarioIdFk = evaluationModel.UsuarioIdFk
            };
            return response;
        }
    }
}