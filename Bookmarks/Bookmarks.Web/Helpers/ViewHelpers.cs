namespace Bookmarks.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Models.ViewModels;

    public static class ViewHelpers
    {
        private static readonly string NewLine = Environment.NewLine;

        public static IHtmlString DisplayBookmark(this HtmlHelper helper, BookmarkListViewModel bookmark)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"col-md-4\">");
            sb.AppendFormat("<h2>{0}</h2>{1}", bookmark.Title, NewLine);

            if (!string.IsNullOrEmpty(bookmark.Description))
            {
                sb.AppendFormat("<p>{0}</p>{1}", bookmark.Description, NewLine);
            }

            if (helper.ViewContext.HttpContext.User.Identity.IsAuthenticated)
            {
                sb.AppendLine(helper.ActionLink("Details", "Details", "Bookmarks", new { title = bookmark.Title }, new { @class = "btn btn-default" }).ToHtmlString());
            }

            sb.AppendLine("</div>");

            return helper.Raw(sb.ToString());
        }

        public static IHtmlString ListBookmarks(this HtmlHelper helper, IList<BookmarkListViewModel> bookmarks)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bookmarks.Count; i++)
            {
                sb.AppendLine("<div class=\"row\">");

                sb.Append(helper.DisplayBookmark(bookmarks[i]));
                i++;
                if (i < bookmarks.Count)
                {
                    sb.Append(helper.DisplayBookmark(bookmarks[i]));
                    i++;
                }

                if (i < bookmarks.Count)
                {
                    sb.Append(helper.DisplayBookmark(bookmarks[i]));
                }

                sb.AppendLine("</div>");
            }

            return helper.Raw(sb.ToString());
        }

        public static IHtmlString Pager(this HtmlHelper helper, int currentPage, int maxPages)
        {
            int previousPage = currentPage > 1 ? currentPage - 1 : currentPage;
            int nextPage = currentPage < maxPages ? currentPage + 1 : currentPage;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<nav>");
            sb.AppendLine("<ul class=\"pagination\">");
            if (currentPage != 1)
            {
                sb.AppendLine("<li>");
                sb.AppendLine("<a href=\"/Bookmarks/Index/" + previousPage + "\" aria-label=\"Previous\">");
                sb.AppendLine("<span aria-hidden=\"true\">&laquo;</span>");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
            }

            for (int i = 1; i <= maxPages; i++)
            {
                if (i == currentPage)
                {
                    sb.AppendLine("<li class=\"active\">" + helper.PageLink(i).ToHtmlString() + "</li>");
                }
                else
                {
                    sb.AppendLine("<li>" + helper.PageLink(i).ToHtmlString() + "</li>");
                }
            }

            if (currentPage != maxPages)
            {
                sb.AppendLine("<li>");
                sb.AppendLine("<a href=\"/Bookmarks/Index/" + nextPage + "\" aria-label=\"Next\">");
                sb.AppendLine("<span aria-hidden=\"true\">&raquo;</span>");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li>");
                sb.AppendLine("<a href=\"/Bookmarks/Index/" + maxPages + "\" aria-label=\"Last\">");
                sb.AppendLine("<span aria-hidden=\"true\">&raquo;&raquo;</span>");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");
            }

            sb.AppendLine("</ul>");
            sb.AppendLine("</nav>");

            return helper.Raw(sb.ToString());
        }

        private static IHtmlString PageLink(this HtmlHelper helper, int pageNumber)
        {
            return helper.ActionLink(pageNumber.ToString(), "Index", "Bookmarks", new { page = pageNumber }, null);
        }
    }
}