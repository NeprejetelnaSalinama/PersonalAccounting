using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using System.Web.Mvc;
using DenisAccounting.Constants;
using DenisAccounting.Models;

namespace DenisAccounting.Managers
{
    public class CurrenciesManager : BaseManager
    {
        public CurrenciesManager(AccountingContext db) : base(db) { }

        public IEnumerable<SelectListItem> GetCurrenciesSelectList(Guid? selectedId)
        {
            var currencies = database
                .Currencies
                .Select(currency => new SelectListItem
                {
                    Value = currency.Id.ToString(),
                    Text = currency.Code,
                    Selected = selectedId.HasValue && selectedId.Value == currency.Id
                })
                .ToList();
            return currencies;
    
        }

        public Currency GetDefaultCurrency()
        {
            var defaultCurrency = database
                .Currencies
                .Single(currenncy => currenncy.Code == SharedConstants.DEFAULT_CURRENCY);
            return defaultCurrency;
        }
    }
}