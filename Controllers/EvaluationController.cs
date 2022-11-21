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

        [HttpPatch("UpdateEvaluation/{id}")]
        public IActionResult Create([FromRoute] long id ,[FromBody] EvaluationModel evaluationModel)
        {
            object response = _evaluationService.UpdateEvaluation(id, evaluationModel);
            return Ok(new { Data = response });
        }

        [HttpGet("FindEvaluation/{id}")]
        public IActionResult findEvaluationById([FromRoute] long id)
        {
            object response = _evaluationService.findEvaluationById(id);
            return Ok(new { Data = response });
        }
    }
}
