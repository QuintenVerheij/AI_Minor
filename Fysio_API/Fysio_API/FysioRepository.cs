using Fysio_API.Auth;
using Fysio_API.Dto;
using Fysio_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API
{
    public class FysioRepository : IFysioRepository
    {
        private readonly FysioDbContext _fysioDbContext;
        public FysioRepository(FysioDbContext fysioDbContext)
        {
            _fysioDbContext = fysioDbContext;
        }


        #region Clients

        public ApplicationUser GetClient(string clientId)
        {
            return _fysioDbContext.ApplicationUser.FirstOrDefault(c => c.Id == clientId);
        }

        #endregion


        #region Therapist

        public void AttachClientToTherapist(int clientId, int therapistId)
        {

        }

        public IEnumerable<ApplicationUser> GetClientsTherapist(string therapistId)
        {
            return _fysioDbContext.ApplicationUser
                .Include(u => u.Clients)
                .ThenInclude(c => c.Client)
                .Where(c => c.Id == therapistId);
        }

        public ApplicationUser GetTherapist(string therapistId)
        {
            return null;
        }

        public void AssignExerciseToClient(ClientExercise clientExercise)
        {
            //Client client = _fysioDbContext.ApplicationUser.Where(u => u.Id == clientExercise.ClientId).Include(c => c.ClientExercises).FirstOrDefault();
            //if (client == null)
            //    throw new ArgumentException(nameof(clientExercise.ClientId));

            //Exercise exercise = _fysioDbContext.Exercises.Where(e => e.ExerciseId == clientExercise.ExerciseId).FirstOrDefault();
            //if (exercise == null)
            //    throw new ArgumentException(nameof(clientExercise.ExerciseId));

            //client.ClientExercises.Add(
            //    new ClientExercise()
            //    {
            //        Exercise = exercise,
            //        WeeklyRepetitions = clientExercise.WeeklyRepetitions,
            //        FinishingDate = clientExercise.FinishingDate
            //    }
            //    );

            //Save();
        }

        #endregion


        #region Exercises
        public Exercise GetExercise(int exerciseId)
        {
            return _fysioDbContext.Exercises.Where(e => e.ExerciseId == exerciseId).FirstOrDefault();
        }

        #endregion

        private bool Save()
        {
            return _fysioDbContext.SaveChanges() > 0;
        }


    }
}
