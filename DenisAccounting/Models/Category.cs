using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DenisAccounting.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual CategoryType CategoryType { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}