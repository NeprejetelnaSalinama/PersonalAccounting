using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DenisAccounting.Models
{
    public class Operation
    {
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual  Category Category { get; set; }
        public virtual Currency Currency { get; set; }
    }
}