using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = Constants.SharedConstants.DATE_FORMAT)]
        public DateTime Date { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Category")]
        public Guid? CategoryId { get; set; }

        public Category.CategoryType categoryType { get; set; }


    }
}