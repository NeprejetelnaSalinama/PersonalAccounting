using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using DenisAccounting.Models;
using DenisAccounting.Models.Operations;
using DenisAccounting.Constants;
using PagedList;
using System.Data;

namespace DenisAccounting.Managers
{
    public class OperationsManager : BaseManager
    {
        public OperationsManager(AccountingContext db) : base(db) { }

        public IEnumerable<Operation> GetOperations()
        {
            var operations = database
                .Operations;
            return operations;
        }

        public IEnumerable<Operation> GetSortedOperations(Sorting sorting)
        {
            var sortedOperations = GetOperations();
            switch (sorting.SortedBy)
            {
                case Sorting.SortType.Date:
                    {
                        sortedOperations = sortedOperations
                                    .OrderByDescending(operation => operation.Date);
                        break;
                    }
                case Sorting.SortType.Amount:
                    {
                        sortedOperations = sortedOperations
                                    .OrderByDescending(operation => operation.Amount);
                        break;
                    }
            }
            if (sorting.Ascending)
            {
                sortedOperations = sortedOperations.Reverse();
            }
            return sortedOperations;
        }

        public IEnumerable<Operation> GetTopOperations(int topN)
        {
            var sortingByDateDesc = new Sorting
            {
                SortedBy = Sorting.SortType.Date,
                Ascending = false
            };
            var operations = GetSortedOperations(sortingByDateDesc).Take(topN);
            return operations;
        }

        public decimal GetBalance()
        {
            var operations = GetOperations();
            decimal balance = operations
                .Select(operation => operation.Amount)
                .Sum();
            return balance;
        }
        
        public IEnumerable<Operation> PaginateOperations(Paging paging, IEnumerable<Operation> operations)
        {
            int page = paging.Page ?? 1;
            paging.Page = page;
            return operations.ToPagedList(page, SharedConstants.PAGE_SIZE);
        }
    }
}