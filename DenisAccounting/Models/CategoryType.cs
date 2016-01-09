using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DenisAccounting.Models
{
    public class CategoryType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}