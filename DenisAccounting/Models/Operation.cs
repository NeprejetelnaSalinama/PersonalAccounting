using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DenisAccounting.Models
{
    public class Operation
    {
        public int OperationID { get; set; }
        public int CurrencyID { get; set; }
        public int CategoryID { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual  Category Category { get; set; }
        public virtual Currency Currency { get; set; }
    }
}