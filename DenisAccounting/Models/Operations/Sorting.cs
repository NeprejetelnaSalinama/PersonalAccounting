using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Sorting
    {
        public bool Asc { get; set; }
        public enum SortValue {Date, Amount }
        public SortValue SortedBy { get; set; }
    }
}