﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Sorting
    {
        public  enum SortType { Date, Amount };
        
        public SortType SortedBy { get; set; }
        public bool Ascending { get; set; }

        public Sorting()
        {
            SortedBy = SortType.Date;
            Ascending = false;
        }
    }
}