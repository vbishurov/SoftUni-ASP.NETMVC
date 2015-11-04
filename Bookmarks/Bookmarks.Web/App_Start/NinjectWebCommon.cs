[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Bookmarks.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Bookmarks.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Bookmarks.Web.App_Start
{
    using System;
    using System.Web;

    using Bookmarks.Data;
    using Bookmarks.Data.UnitOfWork;
    using Bookmarks.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();
        
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBookmarksData>().To<BookmarksData>().InRequestScope().WithConstructorArgument("dbContext", p => new BookmarksDbContext());
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>().InRequestScope().WithConstructorArgument("context", kernel.Get<BookmarksDbContext>());
            kernel.Bind<IAuthenticationManager>().ToMethod<IAuthenticationManager>(context => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
        }
    }
}
