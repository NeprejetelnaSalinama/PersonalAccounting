using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using DenisAccounting.Models;
using DenisAccounting.Models.Operations;
using DenisAccounting.Constants;
using PagedList;
using AutoMapper;
using System;
using System.Data;
using System.Web.Mvc;

namespace DenisAccounting.Managers
{
    public class OperationsManager : BaseManager
    {
        public OperationsManager(AccountingContext db) : base(db) { }

        public IEnumerable<Operation> GetOperations()
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
            var sortedOperations = GetOperations();
            
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
            var operations = GetOperations();
            decimal balance = operations
                .Select(operation => operation.Amount)
                .Sum();
            return balance;
        }

        public void FilterOperations(OperationsListViewModel model, string amountText, string typeText)
        {
            model.Filtering.AmountText = string.Format("{0:0.00}", amountText);
            model.Filtering.TypeText = typeText;

            if (!String.IsNullOrEmpty(amountText)) {
                string amount = $"{model.Filtering.AmountText} {SharedConstants.DEFAULT_CURRENCY}";
                model.Operations = GetOperations()
                        .Where(operation => String.Format("{0:0.00}", operation.Amount) == model.Filtering.AmountText)
                        .Select(Mapper.Map<OperationViewModel>);
            }
            if (String.IsNullOrEmpty(typeText))
            {
                model.Operations = GetOperations()
                        .Where(operation => typeText[0] == '-' ? operation.Amount < 0 : operation.Amount < 0)
                        .Select(Mapper.Map<OperationViewModel>);
            }
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