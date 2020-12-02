using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Car:BaseEntity
    {
        [Required]
        public virtual User User { get; set; }

        [Required]
        public string Plate { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int ModelYear { get; set; }

    }
}
