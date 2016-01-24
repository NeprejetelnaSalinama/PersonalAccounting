﻿using System.Collections.Generic;
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

        private IEnumerable<OperationViewModel> SortOperationsByDate(IEnumerable<OperationViewModel> operations)
        {
            return operations.OrderByDescending(operation => operation.Date);
        }

        private IEnumerable<OperationViewModel> SortOperationsByAmount(IEnumerable<OperationViewModel> operations)
        {
            return operations.OrderByDescending(operation => operation.Amount);
        }

        public OperationsListViewModel SortOperations(OperationsListViewModel model, Sorting.SortType? sortBy)
        {
            if (model.Sorting.SortedBy == sortBy)
            {
                model.Operations.Reverse();
            }
            else
            {
                model.Sorting.SortedBy = sortBy ?? Sorting.SortType.Date;
                switch (sortBy)
                {
                    case Sorting.SortType.Date:
                        {
                            SortOperationsByDate(model.Operations);
                            break;
                        }
                    case Sorting.SortType.Amount:
                        {
                            SortOperationsByAmount(model.Operations);
                            break;
                        }
                }
            }
            return model;

        }

        public IEnumerable<OperationViewModel> GetTopOperations(int topN)
        {
            var operations = GetOperations()
                .Select(Mapper.Map<OperationViewModel>);
            operations = SortOperationsByDate(operations);
            return operations.Take(topN);
        }

        public decimal GetBalance()
        {
            var operations = GetOperations();
            decimal balance = operations
                .Select(operation => operation.Amount)
                .Sum();
            return balance;
        }
        
        public void PaginateOperations(OperationsListViewModel model, int? page)
        {
            model.Paging.Page = page ?? 1;
            model.Operations = model.Operations.ToPagedList(model.Paging.Page, Paging.PAGE_SIZE);
        }
    }
}