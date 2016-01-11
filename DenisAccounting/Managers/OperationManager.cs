using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DenisAccounting.Models;

namespace DenisAccounting.Managers
{
    public class OperationManager : BaseManager
    {
        public IEnumerable<Operation> getOperations()
        {
            var operations = database
                .Operations
                .ToList();
            return operations;
        }

        public IEnumerable<Operation> getSortedOperations()
        {
            var operations = getOperations();
            List<Operation> sortedOperations = operations
                .OrderByDescending(operation => operation.Date)
                .ToList();
            return sortedOperations;
        }

        public IEnumerable<Operation> getTopOperations(int topN)
        {
            var sortedOperations = getSortedOperations();
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