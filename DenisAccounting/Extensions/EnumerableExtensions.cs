using System;
using System.Collections.Generic;
using DenisAccounting.Models.Operations;
using PagedList;
using System.Linq;
using DenisAccounting.Managers;

namespace DenisAccounting.Extensions
{
    public static class EnumerableExtensions
    {
        public static IPagedList<T> AsPaginatedList<T>(IEnumerable<T> items, Paging paging, int totalItemCount)
        {
            int page = paging.Page ?? 1;
            IQueryable<T> qItems = items.AsQueryable();
            var pagedList = new StaticPagedList<T>(qItems, page, Paging.PAGE_SIZE, totalItemCount);
            return pagedList;
        }
    }
}