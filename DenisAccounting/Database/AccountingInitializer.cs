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


            var categories = new List<Category>
            {
            new Category{Type = Category.CategoryType.Income, Name="BasicSalary", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Income , Name="ExtraSalary", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Income , Name="InvestmentIncome", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Income , Name="Gift", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Housing", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Food", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Pets", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Transportation", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Insurance", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Entertainment and Recreation", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Clothing", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Debts", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Phone", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Medical", Id = Guid.NewGuid()},
            new Category{Type = Category.CategoryType.Outcome , Name="Hobbies", Id = Guid.NewGuid()}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

        }
    }
}