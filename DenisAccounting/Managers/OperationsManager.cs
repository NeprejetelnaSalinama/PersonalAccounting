using System;
using System.Collections.Generic;
using System.Linq;
using DenisAccounting.Database;
using DenisAccounting.Models;

namespace DenisAccounting.Managers
{
    public class OperationsManager : BaseManager
    {
        public OperationsManager(AccountingContext db) : base(db) { }


        private IEnumerable<Operation> getOperations()
        {
            var operations = database
                .Operations
                .ToList();
            return operations;
        }
        
        public List<Operation> getSortedOperations(string sortOrder)
        {
            var operations = getOperations();

            switch (sortOrder)
            {
                case null:
                case "Date":
                    operations = operations.OrderBy(operation => operation.Date);
                    break;
                case "Date_Desc":
                    operations = operations.OrderByDescending(operation => operation.Date);
                    break;
                case "Amount":
                    operations = operations.OrderBy(operation => operation.Amount);
                    break;
                case "Amount_Desc":
                    operations = operations.OrderByDescending(operation => operation.Amount);
                    break;
                default:
                    goto case null;
            }

            return operations.ToList();

        }

        public IEnumerable<Operation> getTopOperations(int topN)
        {
            var sortedOperations = getSortedOperations(null);
            List<Operation> topOperations = sortedOperations
                .Take(topN)
                .ToList();
            return topOperations;
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