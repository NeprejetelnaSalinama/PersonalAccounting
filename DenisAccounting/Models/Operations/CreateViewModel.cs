using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;


namespace DenisAccounting.Models.Operations
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            Categories = Enumerable.Empty<SelectListItem>();
        }
        
        public IEnumerable<SelectListItem> Categories { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Category")]
        public Guid? CurrencyId { get; set; }

        [DisplayName("Category")]
        public Guid? CategoryId { get; set; }


    }
}