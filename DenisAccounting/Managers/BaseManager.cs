using DenisAccounting.Database;

namespace DenisAccounting.Managers
{
    public class BaseManager
    {
        protected AccountingContext database = new AccountingContext();
    }
}