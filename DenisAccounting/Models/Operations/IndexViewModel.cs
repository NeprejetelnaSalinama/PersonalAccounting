﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DenisAccounting.Models.Operations
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }

        public string Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string CurrencyCode { get; set; }
    }
}