using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DenisAccounting.Models;

namespace DenisAccounting.Database
{
    public class AccountingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AccountingContext>
    {
        protected override void Seed(AccountingContext context)
        {
            var currencies = new List<Currency>
            {
            new Currency{Code="CZK", Id = Guid.NewGuid()}
            // new Currency{Code="GBP"},
            // new Currency{Code="EUR"}
            };

            context.Currencies.AddRange(currencies);
            context.SaveChanges(); 

            var categoryTypes = new List<CategoryType>
            {
            new CategoryType{Name="Income", Id = Guid.NewGuid()},
            new CategoryType{Name="Outcome", Id = Guid.NewGuid()}
            };

            context.CategoryTypes.AddRange(categoryTypes);
            context.SaveChanges();

            var incomeType = categoryTypes.Find(categoryType => categoryType.Name == "Income");
            var outcomeType = categoryTypes.Find(categoryType => categoryType.Name == "Outcome");

            var categories = new List<Category>
            {
            new Category{CategoryType = incomeType , Name="BasicSalary", Id = Guid.NewGuid()},
            new Category{CategoryType = incomeType , Name="ExtraSalary", Id = Guid.NewGuid()},
            new Category{CategoryType = incomeType , Name="InvestmentIncome", Id = Guid.NewGuid()},
            new Category{CategoryType = incomeType , Name="Gift", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Housing", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Food", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Pets", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Transportation", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Insurance", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Entertainment and Recreation", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Clothing", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Debts", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Phone", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Medical", Id = Guid.NewGuid()},
            new Category{CategoryType = outcomeType , Name="Hobbies", Id = Guid.NewGuid()}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

        }
    }
}