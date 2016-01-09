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

            var categories = new List<Category>
            {
            new Category{ CategoryType = incomeType , Name="BasicSalary", Id = Guid.NewGuid() },
            // new Category{categoryTypes(Name = "Income"), Name="ExtraSalary"},
            // new Category{categoryTypes(Name = "Income"), Name="InvestmentIncome"},
            // new Category{categoryTypes(Name = "Income"), Name="Gift"},
            // new Category{categoryTypes(Name = "Outcome"), Name="Housing"},
            // new Category{categoryTypes(Name = "Outcome"), Name="Food"},
            // new Category{categoryTypes(Name = "Outcome"), Name="Pets"},
            // new Category{categoryTypes(name = "Outcome"), Name="Transportation"},
            // new Category{categoryTypes(name = "Outcome"), Name="Insurance"},
            // new Category{categoryTypes(name = "Outcome"), Name="Entertainment and Recreation"},
            // new Category{categoryTypes(name = "Outcome"), Name="Clothing"},
            // new Category{categoryTypes(name = "Outcome"), Name="Debts"},
            // new Category{categoryTypes(name = "Outcome"), Name="Investments"},
            // new Category{categoryTypes(name = "Outcome"), Name="Phone"},
            // new Category{categoryTypes(name = "Outcome"), Name="Medical"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

        }
    }
}