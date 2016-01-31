using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class Paging
    {
        public const int PAGE_SIZE = 3;

        public int? Page { get; set; }
    }
}