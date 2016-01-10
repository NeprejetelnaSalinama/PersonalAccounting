using DenisAccounting.Database;
using System.Web.Mvc;

namespace DenisAccounting.Controllers
{
    public abstract class BaseController : Controller
    {
        protected AccountingContext database = new AccountingContext();
    }
}