using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DenisAccounting.Models.Operations;
using DenisAccounting.Models;
using DenisAccounting.Managers;
using AutoMapper;

namespace DenisAccounting.Controllers
{
    public class OperationController : BaseController
    {
        private OperationsManager operationsManager;
        private CategoriesManager categoriesManager;
        private CurrenciesManager currenciesManager;

        public OperationController() {
            operationsManager = new OperationsManager(database);
            categoriesManager = new CategoriesManager(database);
            currenciesManager = new CurrenciesManager(database);
        }

        public ViewResult Index()
        {
            var operations = operationsManager.getOperations();
            var operationsModel = operations
                .Select(Mapper.Map<IndexViewModel>);

            return View(operationsModel);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = database.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
            return View(category);
        }

        public ActionResult Create(Category.CategoryType type)
        {
            var currency = currenciesManager.GetDefaultCurrency();
            var categories = categoriesManager.GetCategoriesSelectList(null, type);
            var model = new CreateViewModel
            {
                Categories = categories,
                CurrencyId = currency.Id
            };
            return View();
        }
    }
}
