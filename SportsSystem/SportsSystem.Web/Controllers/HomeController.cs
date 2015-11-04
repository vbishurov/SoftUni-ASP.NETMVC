namespace SportsSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Data.UnitOfWork;
    using BaseControllers;

    public class HomeController : BaseAppController
    {
        public HomeController()
        {
        }

        public HomeController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}