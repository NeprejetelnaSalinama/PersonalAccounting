using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using DenisAccounting.Models;
using DenisAccounting.Models.Operations;
using DenisAccounting.Constants;
using PagedList;
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

        public List<OperationViewModel> GetSortedOperations(string sortBy, bool? asc)
        {
            var sortValue = sortBy ?? "Date";
            var ascOrder = asc ?? true;
            var sortedOperations = getOperations();


            if (sortValue == "Date") {
                if (ascOrder) {
                    sortedOperations = sortedOperations
                        .OrderBy(operation => operation.Date);
                } else {
                    sortedOperations = sortedOperations
                        .OrderByDescending(operation => operation.Date);
                }
            } else if (sortValue == "Amount")
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

        public List<OperationViewModel> GetTopOperations(int topN)
        {
            return GetSortedOperations("Date", true).Take(topN).ToList();
        }

        public decimal GetBalance()
        {
            var operations = getOperations();
            decimal balance = operations
                .Select(operation => operation.Amount)
                .Sum();
            return balance;
        }

        public void FilterOperations(OperationsListViewModel model, string filter, string text)
        {
            /*if (filter.HasValue)
            {
                switch (filter)
                {
                    case Filtering.FiltertValues.Amount:
                        model.Operations = model.Operations
                            .Where(operation => operation.Amount[0] == '-');
                    case Filtering.FiltertValues.Date:
                        model.Operations = model.Operations
                            .Where(operation => operation.Date.Equals(dat);
                }
            }*/
        }

        public void SortOperations(OperationsListViewModel model, string sortedBy, bool? asc)
        {
            model.Sorting.SortedBy = sortedBy ?? "Date";
            model.Sorting.Asc = asc ?? true;
            model.Operations = GetSortedOperations(model.Sorting.SortedBy, model.Sorting.Asc).ToList();
        }

        public void PaginateOperations(OperationsListViewModel model, int? page)
        {
            model.Paging.Page = page ?? 1;
            model.Operations = model.Operations.ToList().ToPagedList(model.Paging.Page, SharedConstants.PAGE_SIZE);
        }
    }
}