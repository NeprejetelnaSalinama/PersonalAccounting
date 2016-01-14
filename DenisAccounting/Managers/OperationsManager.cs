using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using DenisAccounting.Models;
using DenisAccounting.Models.Operations;
using AutoMapper;

namespace DenisAccounting.Managers
{
    public class OperationsManager : BaseManager
    {
        public OperationsManager(AccountingContext db) : base(db) { }

        public IEnumerable<Operation> getOperations()
        {
            var operations = database
                .Operations
                .ToList();
            return operations;
        }

        public List<OperationViewModel> getSortedOperations(Sorting.SortValue? sortBy, bool? asc)
        {
            var sortValue = sortBy ?? Sorting.SortValue.Date;
            var ascOrder = asc ?? true;
            var sortedOperations = getOperations();


            if (sortValue == Sorting.SortValue.Date) {
                if (ascOrder) {
                    sortedOperations = sortedOperations
                        .OrderBy(operation => operation.Date);
                } else {
                    sortedOperations = sortedOperations
                        .OrderByDescending(operation => operation.Date);
                }
            } else if (sortValue == Sorting.SortValue.Amount)
            {
                if (ascOrder)
                {
                    sortedOperations = sortedOperations
                        .OrderBy(operation => operation.Amount);
                }
                else {
                    sortedOperations = sortedOperations
                        .OrderByDescending(operation => operation.Amount);
                }
            }

            var operationsModel = sortedOperations
                .Select(Mapper.Map<OperationViewModel>);



            return operationsModel.ToList(); ;

            }

        public List<OperationViewModel> getTopOperations(int topN)
        {
            return getSortedOperations(Sorting.SortValue.Date, true).Take(topN).ToList();
        }

        public decimal getBalance()
        {
            var operations = getOperations();
            decimal balance = operations
                .Select(operation => operation.Amount)
                .Sum();
            return balance;
        }
    }
}