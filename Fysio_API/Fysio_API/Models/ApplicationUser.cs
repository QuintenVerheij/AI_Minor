using Fysio_API.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public List<ClientExercise> clientExercises { get; set; }
        public List<TherapistClient> therapistClients { get; set; }
    }
}
