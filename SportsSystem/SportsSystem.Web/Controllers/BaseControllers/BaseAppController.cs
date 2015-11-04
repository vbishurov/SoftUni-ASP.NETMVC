namespace SportsSystem.Web.Controllers.BaseControllers
{
    using System.Web.Mvc;

    using Data;
    using Data.UnitOfWork;

    public abstract class BaseAppController : Controller
    {
        protected BaseAppController()
            : this(new BookmarksData(new SportsSystemDbContext()))
        {
        }

        protected BaseAppController(IBookmarksData data)
        {
            this.Data = data;
        }

        protected IBookmarksData Data { get; set; }
    }
}