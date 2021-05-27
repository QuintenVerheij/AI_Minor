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

        public void PairClientTherapist_WithCode(string clientId, string code)
        {
            var client = _fysioDbContext.ApplicationUser.Find(clientId);
            if (client == null)
                throw new ArgumentException(nameof(clientId));

            var therapistLink = _fysioDbContext.PairingCodes.FirstOrDefault(pc => pc.Code == code);
            if (therapistLink == null)
                throw new ArgumentException(nameof(code));

            client.ClientTherapists = new List<TherapistClient>() {
                new TherapistClient()
                {
                    TherapistId = therapistLink.TherapistId
                }
            };

            _fysioDbContext.SaveChanges();
        }

        public void FinishClientExercise(int clientExerciseId)
        {
            var clientExercise = _fysioDbContext.ClientExercises.Find(clientExerciseId);
            if (clientExercise == null)
                throw new ArgumentException(nameof(clientExerciseId));

            clientExercise.WeeklyRepetitionsCompleted += 1;

            if (clientExercise.ClientExerciseLogs == null)
                clientExercise.ClientExerciseLogs = new List<ClientExerciseLog>();

            clientExercise.ClientExerciseLogs.Add(
                new ClientExerciseLog { 
                    DateTime = DateTime.Now
            });
        }


        #endregion


        #region Therapist

        public IEnumerable<ApplicationUser> GetClientsTherapist(string therapistId)
        {
            return _fysioDbContext.ApplicationUser
                                    .Include(u => u.TherapistClients)
                                        .ThenInclude(c => c.Client)
                                    .Where(c => c.Id == therapistId);
        }

        public ApplicationUser GetTherapist(string therapistId)
        {
            return _fysioDbContext.ApplicationUser.Find(therapistId);              
        }

        public void AssignExerciseToClient(ClientExerciseDto_In clientExerciseDto_In)
        {
            ApplicationUser client = _fysioDbContext.ApplicationUser.Find(clientExerciseDto_In.ClientId);
            if (client == null)
                throw new ArgumentException(nameof(clientExerciseDto_In.ClientId));

            Exercise exercise = _fysioDbContext.Exercises.Find(clientExerciseDto_In.ExerciseId);
            if (exercise == null)
                throw new ArgumentException(nameof(clientExerciseDto_In.ExerciseId));

            if (client.clientExercises == null)
                client.clientExercises = new List<ClientExercise>();

            client.clientExercises.Add(
                new ClientExercise()
                {
                    Exercise = exercise,
                    WeeklyRepetitions = clientExerciseDto_In.WeeklyRepetitions,
                    FinishingDate = clientExerciseDto_In.FinishingDate
                }
            );

            _fysioDbContext.SaveChanges();
        }

        #endregion


        #region Exercises
        public Exercise GetExercise(int exerciseId)
        {
            return _fysioDbContext.Exercises.Where(e => e.ExerciseId == exerciseId).FirstOrDefault();
        }

        #endregion

        


    }
}
