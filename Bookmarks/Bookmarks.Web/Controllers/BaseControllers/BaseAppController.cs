namespace Bookmarks.Web.Controllers.BaseControllers
{
    using System.Web.Mvc;

    using Bookmarks.Data.UnitOfWork;

    public abstract class BaseAppController : Controller
    {
        protected BaseAppController(IBookmarksData data)
        {
            this.Data = data;
        }

        protected IBookmarksData Data { get; set; }
    }
}