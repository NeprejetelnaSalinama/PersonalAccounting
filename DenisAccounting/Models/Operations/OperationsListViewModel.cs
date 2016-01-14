using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DenisAccounting.Models.Operations
{
    public class OperationsListViewModel
    {
        [Required]
        public IEnumerable<OperationViewModel> Operations { get; set; }
        public Paging Paging { get; set; }
        public Sorting Sorting { get; set; }
        public Filtering Filtering { get; set; }

        public OperationsListViewModel()
        {
            Operations = Enumerable.Empty<OperationViewModel>();
            Paging = new Paging();
            Sorting = new Sorting();
            Filtering = new Filtering();
        }
    }
}