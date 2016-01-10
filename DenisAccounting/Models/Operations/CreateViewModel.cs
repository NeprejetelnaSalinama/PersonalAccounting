using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models.Operations
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            Categories = Enumerable.Empty<SelectListItem>();
        }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid? CurrencyId { get; set; }
        public Guid? CategoryId { get; set; }


    }
}