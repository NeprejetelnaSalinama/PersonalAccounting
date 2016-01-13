using System;
using System.ComponentModel.DataAnnotations;

namespace DenisAccounting.Models
{
    public class Operation
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        public string Description { get; set; }

        [Required]
        public virtual  Category Category { get; set; }

        [Required]
        public virtual Currency Currency { get; set; }
    }
}