using Fysio_API.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Models
{
    public class ClientExercise
    {
        [Key]
        public int ClientExerciseId { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        [Required]
        public int WeeklyRepetitions { get; set; }
        [Required]
        public int WeeklyRepetitionsCompleted { get; set; }
        [Required]
        public float Score { get; set; }
        [Required]
        public DateTime FinishingDate { get; set; }
        public List<ClientExerciseLog> ClientExerciseLogs { get; set; }
    }
}
