namespace TwitterLike.Controllers.Helpers
{
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Owin.Security;

    internal class ChallengeResult : HttpUnauthorizedResult
    {
        public ChallengeResult(string provider, string redirectUri, string userId = null)
        {
            this.LoginProvider = provider;
            this.RedirectUri = redirectUri;
            this.UserId = userId;
        }

        private string LoginProvider { get; set; }

        private string RedirectUri { get; set; }

        private string UserId { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var properties = new AuthenticationProperties { RedirectUri = this.RedirectUri };
            if (this.UserId != null)
            {
                properties.Dictionary[BaseController.XsrfKey] = this.UserId;
            }
            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, this.LoginProvider);
        }
    }
}