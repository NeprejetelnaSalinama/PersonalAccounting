using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DenisAccounting.Models.Operations;

namespace DenisAccounting.Models.Home
{
    public class HomeViewModel
    {
        public string Balance { get; set; }

        public IEnumerable<Operations.OperationViewModel> Operations { get; set; }

        public HomeViewModel()
        {
            Operations = Enumerable.Empty<OperationViewModel>();
        }
    }
}