using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DenisAccounting.Constants;

namespace DenisAccounting.Models.Operations
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            Categories = Enumerable.Empty<SelectListItem>();
        }
        
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "The Amount is required")]
        [Range(0.01, 9999999.99, ErrorMessage = "The  Price must be between 0.01 and 9999999.99")]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = SharedConstants.DATE_FORMAT)]
        public DateTime Date { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Category")]
        public Guid? CategoryId { get; set; }

        public Category.CategoryType CategoryType { get; set; }


    }
}