using DenisAccounting.Models.Operations;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DenisAccounting.Extensions
{
    public static class RoutingExtensions
    {
        private static RouteValueDictionary FillRouteValueDictionary(Sorting sorting, Paging paging)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary
                {
                    { "model.Sorting.sortedBy", sorting.SortedBy },
                    { "model.Sorting.ascending", sorting.Ascending },
                    { "model.Paging.page", paging.Page }
                };
            return routeValueDictionary;
        }

        public static string ActionEx(this UrlHelper urlHelper, string actionName, Sorting sorting, int page)
        {
            Paging paging = new Paging
            {
                Page = page
            };
            RouteValueDictionary routeValueDictionary = FillRouteValueDictionary(sorting, paging);
            return urlHelper.Action(actionName, routeValueDictionary);
        }

        public static HtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, Sorting sorting, Paging paging)
        {
            RouteValueDictionary routeValueDictionary = FillRouteValueDictionary(sorting, paging);
            return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, routeValueDictionary);
        }
    }
}