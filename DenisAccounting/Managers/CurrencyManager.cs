using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Models;
using System.Web.Mvc;

namespace DenisAccounting.Managers
{
    public class CurrencyManager : BaseManager
    {
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
    }
}