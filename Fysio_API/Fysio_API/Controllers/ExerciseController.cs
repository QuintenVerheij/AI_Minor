using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_API.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        
        public ExerciseController() { }

        [HttpPost("/add")]
        public void AddExercise()
        {

        }

        //[HttpGet("{exerciseId}")]
        //public IActionResult GetExercise(int exerciseId)
        //{
        //    return new JsonResult(_fysioRepository.GetExercise(exerciseId));
        //}

        //[HttpPost("{id}/")]
        //[Authorize(Roles = Role.Client)]
        //public void PairClient(string id, [FromBody] PairCodeDto_In pairCodeDto_In)
        //{
        //    _repo.PairClientTherapist_WithCode(id, pairCodeDto_In.Code);
        //}
    }
}