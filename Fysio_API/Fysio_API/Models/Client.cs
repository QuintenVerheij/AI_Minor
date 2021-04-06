using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<ClientExcercise> ClientExcercises { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }
    }
}
