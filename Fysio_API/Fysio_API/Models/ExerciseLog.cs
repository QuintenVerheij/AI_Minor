using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class ClientExerciseLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientExerciseId { get; set; }
        public ClientExercise clientExercise { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
