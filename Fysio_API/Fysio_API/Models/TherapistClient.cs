using Fysio_API.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio_API.Models
{
    public class TherapistClient
    {
        [Key]
        public int Id { get; set; }
        public string TherapistId { get; set; }
        public ApplicationUser Therapist { get; set; }
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
