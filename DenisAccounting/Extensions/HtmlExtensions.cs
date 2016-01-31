using DenisAccounting.Models.Operations;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DenisAccounting.Extensions
{
    public static class HtmlExtensions
    {
        public static HtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, Sorting sorting, Paging paging)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary
                {
                    { "Sorting", sorting },
                    { "Paging", paging }
                };

            return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, routeValueDictionary);
        }
    }
}