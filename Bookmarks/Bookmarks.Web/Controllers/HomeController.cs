namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using BaseControllers;

    using Data.UnitOfWork;

    using Models.ViewModels;

    public class HomeController : BaseAppController
    {
        public HomeController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index(string notification = null)
        {
            if (notification != null)
            {
                this.ViewBag.NotificationMessage = notification;
            }

            var topBookmarks = this.Data.Bookmarks.All()
                .OrderBy(b => b.Votes.Average(v => v.Stars))
                .Select(b => new BookmarkListViewModel()
                {
                    Title = b.Title,
                    Description = b.Description
                })
                .Take(6)
                .ToList();

            return this.View("Index", topBookmarks);
        }
    }
}