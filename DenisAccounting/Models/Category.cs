using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DenisAccounting.Models
{
    public class Category
    {
        public enum CategoryType { Income, Outcome }; 

        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}