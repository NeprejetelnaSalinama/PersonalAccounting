using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Filtering
    {
        public string DateText { get; set; }
        public string AmountText { get; set; }
        public Category.CategoryType Type { get; set; }
    }
}