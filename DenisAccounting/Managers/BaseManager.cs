using DenisAccounting.Database;

namespace DenisAccounting.Managers
{
    public abstract class BaseManager
    {
        protected AccountingContext database;

        public BaseManager (AccountingContext db)
        {
            database = db;
        }

    }
}