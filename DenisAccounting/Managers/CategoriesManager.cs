using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using System.Web.Mvc;
using DenisAccounting.Models;
using DenisAccounting.Constants;

namespace DenisAccounting.Managers
{
    public class CategoriesManager : BaseManager
    {
        public CategoriesManager(AccountingContext db) : base(db) { }

        public IEnumerable<SelectListItem> GetCategoriesSelectList(Guid? selectedId, Category.CategoryType categoryType)
	    {
            var model = database.Categories
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

        public IEnumerable<SelectListItem> GetCategoryTypeList(Category.CategoryType? selected)
        {
            yield return new SelectListItem
            {
                Value = String.Empty,
                Text = SharedConstants.NOT_SELECTED,
                Selected = !selected.HasValue
            };

            yield return new SelectListItem
            {
                Value = Category.CategoryType.Income.ToString(),
                Text = "Incomes only",
                Selected = !selected.HasValue
            };

            yield return new SelectListItem
            {
                Value = Category.CategoryType.Outcome.ToString(),
                Text = "Outcomes only",
                Selected = !selected.HasValue
            };
        }
    }   
}