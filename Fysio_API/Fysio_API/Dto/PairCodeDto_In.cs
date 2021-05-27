using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Dto
{
    public class PairCodeDto_In
    {
        [StringLength(5)]
        public string Code { get; set; }
    }
}
