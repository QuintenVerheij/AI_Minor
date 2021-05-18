using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        [ForeignKey("Therapist")]
        public int CreatedByTherapist_Id { get; set; }
        public Therapist CreatedByTherapist { get; set; }
        public string VideoLink { get; set; }
    }
}
