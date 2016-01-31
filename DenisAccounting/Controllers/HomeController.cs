using System.Linq;
using System.Web.Mvc;
using DenisAccounting.Managers;
using DenisAccounting.Models.Operations;
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

            var operationsModel = operationsManager.GetTopOperations(TOP_OPERATIONS).Select(Mapper.Map<OperationViewModel>);
            
            var model = new Models.Home.IndexViewModel
            {
                Balance = $"{operationsManager.GetBalance().ToString()} {SharedConstants.DEFAULT_CURRENCY}",
                Operations = operationsModel
            };
    

        return View(model);
        }
    }
}