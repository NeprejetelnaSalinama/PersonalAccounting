using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DenisAccounting.Models.Operations
{
    public class OperationViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DisplayName ("Amount")]
        public string Amount { get; set; }

        [Required]
        [DisplayName ("Date")]
        public String Date { get; set; }

        [DisplayName ("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName ("Category")]
        public string CategoryName { get; set; }

        [Required]
        [DisplayName("Currency")]
        public string CurrencyCode { get; set; }
    }
}