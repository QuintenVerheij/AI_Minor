using Fysio_API.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class PairingCodes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Code { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string TherapistId { get; set; }
        public ApplicationUser Therapist { get; set; }
    }
}
