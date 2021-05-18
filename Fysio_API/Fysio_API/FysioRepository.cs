//using Fysio_API.Dto;
//using Fysio_API.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Fysio_API
//{
//    public class FysioRepository : IFysioRepository
//    {
//        private readonly FysioDbContext _fysioDbContext;
//        public FysioRepository(FysioDbContext fysioDbContext)
//        {
//            _fysioDbContext = fysioDbContext;
//        }


//        # region Clients
        
//        public Client GetClient(int clientId)
//        {
//            return _fysioDbContext.Clients.FirstOrDefault(c => c.ClientId == clientId);
//        }

//        #endregion


//        #region Therapist
//        public void AddTherapist(Therapist therapist)
//        {
//            if (therapist == null)
//                throw new ArgumentNullException(nameof(therapist));

//            _fysioDbContext.Add(therapist);
//        }

//        public void AttachClientToTherapist(int clientId, int therapistId)
//        {

//        }

//        public IEnumerable<Client> GetClientsTherapist(int therapistId)
//        {
//            return _fysioDbContext.Clients.Where(c => c.TherapistId == therapistId).ToList();
//        }

//        public Therapist GetTherapist(int therapistId)
//        {
//            return _fysioDbContext.Therapists.Where(t => t.TherapistId == therapistId).Include(t => t.Clients).FirstOrDefault();
//        }

//        public void AssignExerciseToClient(ClientExercise clientExercise)
//        {
//            Client client = _fysioDbContext.ApplicationUser.Where(u => u.Id == clientExercise.ClientId).Include(c => c.ClientExercises).FirstOrDefault();
//            if (client == null)
//                throw new ArgumentException(nameof(clientExercise.ClientId));

//            Exercise exercise = _fysioDbContext.Exercises.Where(e => e.ExerciseId == clientExercise.ExerciseId).FirstOrDefault();
//            if (exercise == null)
//                throw new ArgumentException(nameof(clientExercise.ExerciseId));

//            client.ClientExercises.Add(
//                new ClientExercise()
//                {
//                    Exercise = exercise,
//                    WeeklyRepetitions = clientExercise.WeeklyRepetitions,
//                    FinishingDate = clientExercise.FinishingDate
//                }
//                );

//            Save();
//        }

//        #endregion


//        #region Exercises
//        public Exercise GetExercise(int exerciseId)
//        {
//            return _fysioDbContext.Exercises.Where(e => e.ExerciseId == exerciseId).FirstOrDefault();
//        }

//        #endregion

//        private bool Save()
//        {
//            return _fysioDbContext.SaveChanges() > 0;
//        }


//    }
//}
