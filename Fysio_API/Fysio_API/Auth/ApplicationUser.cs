using Fysio_API.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("ApplicationUser")]
        public string TherapistId { get; set; }
        public ApplicationUser Therapist { get; set; }
        public List<ClientExercise> clientExercises { get; set; }
    }
}
