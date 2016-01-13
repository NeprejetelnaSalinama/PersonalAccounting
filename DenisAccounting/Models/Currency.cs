using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenisAccounting.Models
{
    public class Currency
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}