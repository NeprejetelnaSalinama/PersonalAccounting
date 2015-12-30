using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DenisAccounting.Models;

namespace DenisAccounting.DAL
{
    public class AccountingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AccountingContext>
    {
        protected override void Seed(AccountingContext context)
        {
            var currencies = new List<Currency>
            {
            new Currency{Code="CZK"},
            new Currency{Code="EUR"},
            new Currency{Code="GBP"}
            };

            currencies.ForEach(s => context.Currencies.Add(s));
            context.SaveChanges(); // not necessary but helps to locate a problem if an exception occurs

            var categoryTypes = new List<CategoryType>
            {
            new CategoryType{name="Income"},
            new CategoryType{name="Outcome"}
            };

            categoryTypes.ForEach(s => context.CategoryTypes.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
            new Category{CategoryTypeID=1,Name="BasicSalary"},
            new Category{CategoryTypeID=1,Name="ExtraSalary"},
            new Category{CategoryTypeID=1,Name="InvestmentIncome"},
            new Category{CategoryTypeID=1,Name="Gift"},
            new Category{CategoryTypeID=2,Name="Housing"},
            new Category{CategoryTypeID=2,Name="Food"},
            new Category{CategoryTypeID=2,Name="Pets"},
            new Category{CategoryTypeID=2,Name="Transportation"},
            new Category{CategoryTypeID=2,Name="Insurance"},
            new Category{CategoryTypeID=2,Name="Entertainment and Recreation"},
            new Category{CategoryTypeID=2,Name="Clothing"},
            new Category{CategoryTypeID=2,Name="Debts"},
            new Category{CategoryTypeID=2,Name="Investments"},
            new Category{CategoryTypeID=2,Name="Phone"},
            new Category{CategoryTypeID=2,Name="Medical"}
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var operations = new List<Operation>
            {
            new Operation{CategoryID=1,CurrencyID=1,Amount=20000.00f,Date=DateTime.Parse("10.12.2015 0:00:00"),Description="Salary 11/2015"},
            new Operation{CategoryID=2,CurrencyID=1,Amount=10000.00f,Date=DateTime.Parse("2015-13-10 00:00:00"),Description="Housing 11/2015"}
            };

            operations.ForEach(s => context.Operations.Add(s));
            context.SaveChanges();
        }
    }
}