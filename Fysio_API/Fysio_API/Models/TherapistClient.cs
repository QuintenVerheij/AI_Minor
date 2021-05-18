using Fysio_API.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Models
{
    public class TherapistClient
    {
        [ForeignKey("ApplicationUser")]
        public string TherapistId { get; set; }
        public ApplicationUser Therapist { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
