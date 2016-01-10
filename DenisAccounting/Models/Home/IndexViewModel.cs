using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DenisAccounting.Models.Operations;

namespace DenisAccounting.Models.Home
{
    public class IndexViewModel
    {
        public string Balance { get; set; }

        public IEnumerable<Operations.IndexViewModel> Operations { get; set; }

        public IndexViewModel()
        {
            Operations = Enumerable.Empty<Operations.IndexViewModel>();
        }
    }
}