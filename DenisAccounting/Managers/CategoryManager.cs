using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace DenisAccounting.Managers
{
    public class CategoryManager : BaseManager
{

        public IEnumerable<SelectListItem> GetCategoriesSelectList(Guid? selectedId, Guid typeId)
	{
            var model = db
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