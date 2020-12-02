using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Appointment:BaseEntity
    {
        public virtual Car Car { get; set; }

        [Required]
        public DateTime Datetime { get; set; }

    }
}
