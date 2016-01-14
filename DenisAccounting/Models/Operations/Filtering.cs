using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Filtering
    {
        public bool DateFiltered { get; set; }
        public bool AmountFiltered { get; set; }
        public bool TypeFiltered { get; set; }
        public string DateText { get; set; }
        public string AmountText { get; set; }
        public string TypeText { get; set; }
    }
}