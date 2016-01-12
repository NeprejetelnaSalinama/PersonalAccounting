using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DenisAccounting.Models.Operations
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }

        [DisplayName ("Amount")]
        public string Amount { get; set; }

        [DisplayName ("Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = Constants.SharedConstants.DATE_FORMAT)]
        public DateTime Date { get; set; }

        [DisplayName ("Description")]
        public string Description { get; set; }

        [DisplayName ("Category")]
        public string CategoryName { get; set; }

        public string CurrencyCode { get; set; }
    }
}