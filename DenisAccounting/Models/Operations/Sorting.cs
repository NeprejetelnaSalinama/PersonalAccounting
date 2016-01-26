using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Sorting
    {
        public  enum SortType { Unsorted, Date, Amount };
        
        public SortType SortedBy { get; set; }
        public bool Revert { get; set; }

        public Sorting()
        {
            SortedBy = SortType.Unsorted;
            Revert = false;
        }
    }
}