using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Filtering
    {

        public enum FiltertValues { Date, Amount }
        public FiltertValues FilteredBy { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public Category.CategoryType Type { get; set; }
    }
}