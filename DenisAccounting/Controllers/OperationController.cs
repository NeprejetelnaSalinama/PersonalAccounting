using System;
using System.Data;
using System.Linq;
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
                .Select(Mapper.Map<OperationViewModel>);
            OperationsListViewModel model = new OperationsListViewModel();
            model.Operations = operationsModel;
            
            return View(model);
        }
    

        
        public ActionResult Details(Guid? id)
        {
            Operation operation = database.Operations.Find(id);
                if (operation == null)
                {
                    return HttpNotFound();
                }
            var model = Mapper.Map<Operation, OperationViewModel>(operation);

            return View(model);
        }

        private ViewResult FillCreateModel(CreateViewModel model)
        {
            model.Categories = categoriesManager.GetCategoriesSelectList(model.CategoryId, model.CategoryType);
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


        public ActionResult AddOutcome()
        {
            return RedirectToAction("Create", new { type = Category.CategoryType.Outcome });
        }

        public ActionResult AddIncome()
        {
            return RedirectToAction("Create", new { type = Category.CategoryType.Income });
        }


        [HttpGet]
        public ActionResult Create(Category.CategoryType type)
        {
            if (type == null)
            {
                return HttpNotFound();
            }

            var model = new CreateViewModel();
            model.CategoryType = type;

            return FillCreateModel(model);
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
                operation.Currency = currenciesManager.GetDefaultCurrency();
                if (model.CategoryType == Category.CategoryType.Outcome)
                {
                    operation.Amount = model.Amount * -1;
                }

                database.Operations.Add(operation);
                database.SaveChanges();
                
                return RedirectToAction("Index");
            }
                        
            FillCreateModel(model);
            return View(model);
        }

        public ActionResult Delete(Guid? id)
        {
            Operation operation = database.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<Operation, OperationViewModel>(operation);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Operation operation = database.Operations.Find(id);
            database.Operations.Remove(operation);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
