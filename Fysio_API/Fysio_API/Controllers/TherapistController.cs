//using AutoMapper;
//using Fysio_API.Dto;
//using Fysio_API.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;

//namespace Fysio_API.Controllers
//{
//    [Route("api/therapist")]
//    [ApiController]
//    public class TherapistController : ControllerBase
//    {
        
//        public TherapistController()
//        {
         
//        }

        

//        [HttpGet("{therapistId}")]
//        public IActionResult GetTherapist(int therapistId)
//        {
//            Therapist resTherapist = _fysioRepository.GetTherapist(therapistId);
//            if (resTherapist == null)
//                return NotFound();
//            else
//                return new JsonResult(resTherapist);
//        }

//        [HttpGet("{therapistId}/clients")]
//        public IActionResult GetClientsTherapist(int therapistId)
//        {
//            return new JsonResult(_fysioRepository.GetClientsTherapist(therapistId));
//        }

//        [HttpPost("{therapistId}/assignexc")]
//        public void AssignExerciseToClient([FromBody] ClientExerciseDto_In clientExerciseDto_In)
//        {
//            _fysioRepository.AssignExerciseToClient(_mapper.Map<ClientExercise>(clientExerciseDto_In));
//        }


//    }
//}