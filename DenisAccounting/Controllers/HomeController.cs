using System.Linq;
using System.Web.Mvc;
using DenisAccounting.Managers;
using AutoMapper;
using DenisAccounting.Constants;

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

            var operationsModel = operationsManager.getTopOperations(TOP_OPERATIONS);
            
            var model = new Models.Home.IndexViewModel
            {
                Balance = $"{operationsManager.getBalance().ToString()} {SharedConstants.DEFAULT_CURRENCY}",
                Operations = operationsModel
            };
    

        return View(model);
        }
    }
}