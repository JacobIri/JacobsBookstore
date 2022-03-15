using JacobsBookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacobsBookstore.Infrastructure
{
    [HtmlTargetElement("div", Attributes ="page-meh")]
    public class PaginationTageHelper : TagHelper
    {
        //dynamically create the page links for us
        private IUrlHelperFactory uhf;

        public PaginationTageHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }



        //
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; } //Need ViewContext for IUrlHelper
        //



        public PageInfo PageMeh { get; set; } //*SAME PageMeh as page-meh
        public string PageAction { get; set; }


        //TagHelperContext tools we use to build tags dynamically
        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div"); //This div will be looping through and adding the individual links

            for (int i = 1; i < PageMeh.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
