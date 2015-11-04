namespace Bookmarks.Web.Controllers.BaseControllers
{
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    public abstract class BaseIdentityController : Controller
    {
        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;

        protected BaseIdentityController(ApplicationUserManager userManager = null, ApplicationSignInManager signInManager = null)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        protected IAuthenticationManager AuthenticationManager => this.HttpContext.GetOwinContext().Authentication;

        protected ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set
            {
                this.signInManager = value;
            }
        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.userManager != null)
                {
                    this.userManager.Dispose();
                    this.userManager = null;
                }

                if (this.signInManager != null)
                {
                    this.signInManager.Dispose();
                    this.signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}