using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using System.Data.Entity;
using System.Web.Mvc;

namespace DenisAccounting.Managers
{
    public class CategoriesManager : BaseManager
{
        public CategoriesManager(AccountingContext db) : base(db) { }

        public IEnumerable<SelectListItem> GetCategoriesSelectList(Guid? selectedId, Guid typeId)
	    {
            var model = database
                .Categories
                .Include(category => category.CategoryType)
                .Where(category => category.CategoryType.Id == typeId)
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