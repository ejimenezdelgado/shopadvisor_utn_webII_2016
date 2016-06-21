using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HtmlExtension
{
    public static class HtmlHelpers
    {
        public static string Label(string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString ActionLinkSortable(this HtmlHelper helper, 
            string linkText, string actionName,
 string sortField, string currentSort, object currentDesc)
        {
            bool desc = (currentDesc == null) ? false : Convert.ToBoolean(currentDesc);
            //get link route values   
            var routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("id", sortField);
            routeValues.Add("desc", (currentSort == sortField) && !desc);
            //build the tag   
            if (currentSort == sortField) linkText = string.Format("{0} <span class='badge'><span class='glyphicon glyphicon-sort-by-attributes{1}'></span></span>", linkText, (desc) ? "-alt" : "");
            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = linkText;
            //add url to the link   
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName, routeValues);
            tagBuilder.MergeAttribute("href", url);
            //put it all together   
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString TextboxEmail(this HtmlHelper helper,string value)
        {
            string str = "<input type=\"email\" value=\"" + value + "\" />";
            return new MvcHtmlString(str);
        }


    }
}
