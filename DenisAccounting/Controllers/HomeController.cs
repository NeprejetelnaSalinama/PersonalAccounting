using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web.Mvc;
using DenisAccounting.Managers;
using AutoMapper;
using DenisAccounting.Models;
using DenisAccounting.Constants;
using DenisAccounting.Database;

namespace DenisAccounting.Controllers
{
    public class HomeController : BaseController
    {
        private OperationsManager operationsManager;

        public HomeController()
        {
            operationsManager = new OperationsManager(database);
        }


        public ViewResult Index()
        {
            const int TOP_OPERATIONS = 10;

            var operations = operationsManager.getTopOperations(TOP_OPERATIONS);
            var operationsModel = operations.
                    Select(Mapper.Map<Models.Operations.OperationViewModel>);

            var model = new Models.Home.IndexViewModel
            {
                Balance = $"{operationsManager.getBalance().ToString()} {SharedConstants.DEFAULT_CURRENCY}",
                Operations = operationsModel
            };
    

        return View(model);
        }
    }
}