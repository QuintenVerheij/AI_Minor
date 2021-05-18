using Fysio_API.Auth;
using Fysio_API.Dto;
using Fysio_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API
{
    public interface IFysioRepository
    {
        ApplicationUser GetClient(string clientId);
        IEnumerable<ApplicationUser> GetClientsTherapist(string therapistId);
        ApplicationUser GetTherapist(string therapistId);
        void AttachClientToTherapist(int clientId, int therapistId);
        void AssignExerciseToClient(ClientExercise clientExercise);
        Exercise GetExercise(int exerciseId);
    }
}
