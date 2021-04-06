using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class ClientExcercise
    {
        [Key]
        public int ClientExcerciseId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public int ExcerciseId { get; set; }
        public Excercise Excercise { get; set; }
        [Required]
        public int WeeklyRepetitions { get; set; }
        [Required]
        public int WeeklyRepetitionsCompleted { get; set; }
        [Required]
        public float Score { get; set; }
        [Required]
        public DateTime FinishingDate { get; set; }
    }
}
