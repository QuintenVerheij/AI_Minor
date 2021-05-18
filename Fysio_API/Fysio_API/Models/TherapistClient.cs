using Fysio_API.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Models
{
    public class TherapistClient
    {
        [Key]
        public int TherapistClientId { get; set; }
        public string TherapistId { get; set; }
        [ForeignKey("Therapist")]
        public ApplicationUser Therapist { get; set; }
        [ForeignKey("Clients")]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
