using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenisAccounting.Models
{
    public class Category
    {
        public enum CategoryType { Income, Outcome };

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public CategoryType Type { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}