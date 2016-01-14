using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using System.Data.Entity;
using System.Web.Mvc;
using DenisAccounting.Models;
using DenisAccounting.Constants;

namespace DenisAccounting.Managers
{
    public class CategoriesManager : BaseManager
    {
        public CategoriesManager(AccountingContext db) : base(db) { }

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

        public IEnumerable<SelectListItem> GetCategoriesList(Guid? selected = null, Category.CategoryType? type = null)
        {
            IEnumerable<Category> categories = database
                .Categories
                .Include(category => category.Type);

            if (type.HasValue)
            {
                categories = categories.Where(category => category.Type == type.Value);
            }

            return categories
                .Select(category => new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name,
                    Selected = selected.HasValue && category.Id == selected
                });
        }

        public IEnumerable<SelectListItem> GetAllCategoriesList(Guid? selected = null)
        {
            yield return new SelectListItem
            {
                Value = String.Empty,
                Text = SharedConstants.NOT_SELECTED,
                Selected = !selected.HasValue
            };

            var categoryItems = GetCategoriesList(selected);
            foreach (SelectListItem item in categoryItems)
            {
                yield return item;
            }
        }


    }   
}