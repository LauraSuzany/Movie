using Microsoft.AspNetCore.Mvc;
using Movie.Entity;
using Movie.Service;
using MovieProject.Models;
using MovieProject.Service;

namespace MovieProject.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] EvaluationModel evaluationModel)
        {
            object response = _evaluationService.AddEvaluation(evaluationModel);
            return Ok(new { Data = response });
        }
    }
}
