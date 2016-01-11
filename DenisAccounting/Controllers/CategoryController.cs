using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DenisAccounting.Managers;
using DenisAccounting.Models;
using AutoMapper;

namespace DenisAccounting.Controllers
{
    public class CategoryController : BaseController
    {
        private CategoriesManager categoriesManager;

        public CategoryController()
        {
            categoriesManager = new CategoriesManager(database);
        }

        //public ViewResult IncomeIndex()
        //{
            

            //var categories = categoriesManager.GetCategoriesSelectList();
            //var categoriesModel = categories
            //    .Select(Category);

           // return View(categoriesModel);
        //}
    }
}
