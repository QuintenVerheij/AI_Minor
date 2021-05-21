using Fysio_API.Auth;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<ClientExercise> ClientExercises { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string CreatedByTherapistId { get; set; }
        public ApplicationUser CreatedByTherapist { get; set; }
        public string VideoLink { get; set; }
    }
}
