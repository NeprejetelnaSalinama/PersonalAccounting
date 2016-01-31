using System;
using System.Collections.Generic;
using DenisAccounting.Models.Operations;
using PagedList;
using System.Linq;

namespace DenisAccounting.Extensions
{
    public static class EnumerableExtensions
    {
        public static IPagedList<T> AsPaginatedList<T>(IEnumerable<T> items, Paging paging)
        {
            int page = paging.Page ?? 1;
            IQueryable<T> qItems = items.AsQueryable();
            var pagedList = new PagedList<T>(qItems, page, Paging.PAGE_SIZE);
            return pagedList;
        }
    }
}