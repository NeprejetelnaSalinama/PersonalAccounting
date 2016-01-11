﻿using System;
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


        public ViewResult Home()
        {
            const int TOP_OPERATIONS = 10;

            var operations = operationsManager.getTopOperations(TOP_OPERATIONS);
            var operationsModel = Mapper.Map<Models.Operations.IndexViewModel>(operations);

            var model = new Models.Home.IndexViewModel
            {
                Balance = $"{operationsManager.getBalance().ToString()} {Constants.SharedConstants.DEFAULT_CURRENCY}",
                Operations = new IEnumerable<Models.Operations.IndexViewModel>
                {

                }
            };
    

        return View(model);
        }
    }
}