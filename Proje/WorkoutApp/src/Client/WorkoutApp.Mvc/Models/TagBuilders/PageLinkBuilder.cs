using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WorkoutApp.Mvc.Models.TagBuilders
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkBuilderTagHelper : TagHelper
    {
        public string PageAction { get; set; } = null!;
        public PagingInfo PageModel { get; set; } = null!;
        private readonly IUrlHelperFactory _urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        public PageLinkBuilderTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var navTag = new TagBuilder("nav");
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination pagination-dark justify-content-center");
            var previousTagUrl = urlHelper.Action(PageAction, new { pageNo = PageModel.CurrentPage - 1});
            var previousTag = CreatePageItem("Previous", PageModel.CurrentPage > 1, previousTagUrl);
            ulTag.InnerHtml.AppendHtml(previousTag);

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                var liTag = new TagBuilder("li");
                liTag.AddCssClass("page-item");
                if (i == PageModel.CurrentPage)
                {
                    liTag.AddCssClass("active");
                }

                var aTag = new TagBuilder("a");
                aTag.AddCssClass("page-link");
                aTag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNo = i });
                aTag.InnerHtml.Append(i.ToString());

                liTag.InnerHtml.AppendHtml(aTag);
                ulTag.InnerHtml.AppendHtml(liTag);
            }

            var isEnable = PageModel.CurrentPage < PageModel.TotalPages;
            var nextTagUrl = urlHelper.Action(PageAction, new { pageNo = PageModel.CurrentPage + 1 });
            var nextTag = CreatePageItem("Next", isEnable, nextTagUrl);
            ulTag.InnerHtml.AppendHtml(nextTag);

            navTag.InnerHtml.AppendHtml(ulTag);
            output.Content.AppendHtml(navTag);
        }

        private TagBuilder CreatePageItem(string text, bool isEnabled, string? url)
        {
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            if (!isEnabled)
            {
                liTag.AddCssClass("disabled");
            }

            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            if (isEnabled)
            {
                aTag.Attributes["href"] = url;
            }
            aTag.InnerHtml.Append(text);

            liTag.InnerHtml.AppendHtml(aTag);
            return liTag;
        }
    }
}
