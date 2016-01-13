using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace DenisAccounting.Models.Home
{
    public class IndexViewModel
    {
        [DisplayFormat(DataFormatString = "{0:#.00$}")]
        [Required]
        public string Balance { get; set; }

        [Required]
        public IEnumerable<Operations.OperationViewModel> Operations { get; set; }

        public IndexViewModel()
        {
            Operations = Enumerable.Empty<Operations.OperationViewModel>();
        }
    }
}