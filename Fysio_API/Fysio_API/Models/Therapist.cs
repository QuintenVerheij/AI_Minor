using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class Therapist
    {
        [Key]
        public int TherapistId { get; set; }
        public ICollection<Client> Clients { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }
    }
}
