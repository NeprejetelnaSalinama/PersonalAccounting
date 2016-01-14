using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using System.Web.Mvc;
using DenisAccounting.Models;

namespace DenisAccounting.Managers
{
    public class CategoriesManager : BaseManager
    {
        public CategoriesManager(AccountingContext db) : base(db) { }

        public IEnumerable<SelectListItem> GetCategoriesSelectList(Guid? selectedId, Category.CategoryType categoryType)
	    {
            var model = database
                .Categories
                .Where(category => category.Type == categoryType)
                .Select(category => new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name,
                    Selected = selectedId.HasValue && selectedId.Value == category.Id
                })
                .ToList();
            return model;
	    }

        
    }   
}