using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Beamore.API.OAuth.Providers;

[assembly: OwinStartup(typeof(Beamore.API.OAuth.Startup))]

namespace Beamore.API.OAuth
{
   
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            ConfigureOAuth(appBuilder);

            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }

        private void ConfigureOAuth(IAppBuilder appBuilder)
        {
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"), // token alacağımız path'i belirtiyoruz
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                AllowInsecureHttp = true,
                Provider = new SimpleAuthorizationServerProvider()
            };

            // AppBuilder'a token üretimini gerçekleştirebilmek için ilgili authorization ayarlarımızı veriyoruz.
            appBuilder.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

            // Authentication type olarak ise Bearer Authentication'ı kullanacağımızı belirtiyoruz.
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
