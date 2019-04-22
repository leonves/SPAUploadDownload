using ApiLTMTest.Services.IoC;
using ApiLTMTest.Application.Service;
using ApiLTMTest.Application.Service.Interfaces;
using ApiLTMTest.Domain.Context;
using ApiLTMTest.Domain.Entities;
using ApiLTMTest.Host.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(ApiLTMTest.Host.Startup))]
namespace ApiLTMTest.Host
{
    public class Startup
    {
        public static Container Container = new Container();

        public void Configuration(IAppBuilder app)
        {

            var config = new HttpConfiguration();

            Container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            BootStrapper.RegisterServices(Container);

            Container.RegisterSingleton(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && Container.IsVerifying)
                    return new OwinContext().Authentication;

                return HttpContext.Current.GetOwinContext().Authentication;

            });

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);

            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(Container))
                {
                    await next?.Invoke();
                }
            });


            var OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Auth/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationProvider(),
            };

            //Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}
