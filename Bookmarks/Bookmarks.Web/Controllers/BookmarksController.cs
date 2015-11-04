namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using BaseControllers;

    using Data.UnitOfWork;

    using Helpers;

    using Models.ViewModels;

    public class BookmarksController : BaseAppController
    {
        private const int PageSize = 3;

        public BookmarksController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1)
        {
            var query = this.Data.Bookmarks.All();

            var model = query
                .OrderBy(b => b.Votes.Average(v => v.Stars))
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(b => new BookmarkListViewModel()
                {
                    Title = b.Title,
                    Description = b.Description
                })
                .GroupBy(p => new QueryTotalSize { Total = query.Count() })
                .FirstOrDefault();

            if (model == null)
            {
                return this.Index();
            }

            this.ViewBag.PageSize = PageSize;
            this.ViewBag.CurrentPage = page;

            return this.View("Index", model);
        }

        [Authorize]
        public ActionResult Details(string title)
        {
            var model = this.Data.Bookmarks.All()
                    .Where(b => b.Title == title)
                    .Select(b => new BookmarkDetailsViewModel()
                        {
                            Category = new CategoryViewModel() { Name = b.Category.Name },
                            Comments = b.Comments.Select(c => new CommentViewModel() { Text = c.Text, Username = c.User.UserName }).ToList(),
                            Description = b.Description,
                            Title = b.Title,
                            Url = b.Url,
                            Votes = b.Votes.Select(v => new VoteViewModel() { Stars = v.Stars, Username = v.User.UserName }).ToList(),
                            AverageRating = b.Votes.Average(v => v.Stars),
                            VotesCount = b.Votes.Count
                        })
                    .FirstOrDefault();

            return this.View("Details", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Vote(string stars)
        {
            return this.Json(new { });
        }
    }
}