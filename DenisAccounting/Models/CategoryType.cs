using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DenisAccounting.Models
{
    public class CategoryType
    {
        public int CategoryTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}