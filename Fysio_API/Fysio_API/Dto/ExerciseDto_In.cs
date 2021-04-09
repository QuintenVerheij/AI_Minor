using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Dto
{
    public class ExerciseDto_In
    {
        public string Name { get; set; }
        public int CreatedByTherapist_Id { get; set; }
        public string VideoLink { get; set; }
    }
}
