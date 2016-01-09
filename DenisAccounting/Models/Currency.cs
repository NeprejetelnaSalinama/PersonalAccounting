using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenisAccounting.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}