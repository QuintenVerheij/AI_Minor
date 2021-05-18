using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Dto
{
    public class ClientExerciseDto_In
    {
        public int ClientId { get; set; }
        public int ExerciseId { get; set; }
        public int WeeklyRepetitions { get; set; }
        public DateTime FinishingDate { get; set; }
    }
}
