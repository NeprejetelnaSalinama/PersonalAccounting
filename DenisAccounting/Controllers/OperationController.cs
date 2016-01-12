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

        private ViewResult FillCreateModel(CreateViewModel model, Category.CategoryType type)
        {
            model.Categories = categoriesManager.GetCategoriesSelectList(model.CategoryId, type);
            return View(model);        
        }

        private void ValidateCreateModel(CreateViewModel model)
        {
            if (model.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Enter Amount greater than 0.");


            }

            if (!database.Categories.Where(category => category.Id == model.CategoryId).Any())
            {
                ModelState.AddModelError("CategoryId", "Category not found. Pick one from the list.");


            }
        }

        public ActionResult Create(Category.CategoryType type)
        {
            var currency = currenciesManager.GetDefaultCurrency();
            var categories = categoriesManager.GetCategoriesSelectList(null, type);
            var model = new CreateViewModel();

            FillCreateModel(model, type);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            ValidateCreateModel(model);

            if (ModelState.IsValid)
            {
                var category = database.Categories.Find(model.CategoryId);

                var operation = Mapper.Map<CreateViewModel, Operation>(model);
                operation.Id = Guid.NewGuid();
                operation.Category = category;

                database.Operations.Add(operation);

                return RedirectToAction("Index");
            }

            FillCreateModel(model, database.Categories.Where(category => category.Id == model.CategoryId).Select(d => d.Type).ToList().First() );
            return View(model);
        }
    }
}
