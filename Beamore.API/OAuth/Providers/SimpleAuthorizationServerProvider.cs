using Beamore.API.BusinessLogics.CO;
using Beamore.API.BusinessLogics.UnitOfWorks;
using Beamore.DAL.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Beamore.API.OAuth.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private string ErrorMessage = "";
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Sisteme giris yapilirken, client'a kullanici rolunu gonderebilmek icin yazilan fonksiyondur.
        /// </summary>
        /// <param name="context"></param>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }


        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            string UserEmail = context.UserName;
            string UserPassword = context.Password;



            // User dan gelen Email ve Password değerleri null mi kontrol ediyor.
            if (NullUserEmailPasswordControl(context.UserName, context.Password))
            {
                context.SetError("Autorization Error", "Gerekli alanları doldurun.");
                //context.SetError("Autorization Error", Resources.WebApiResource.GerekliAlan);
                context.Response.Headers.Add("AuthorizationResponse", new[] { "Failed" });
            }
            var response = RegisteredEndUserControl(UserEmail, UserPassword);
            if (response.Status)
            {
                var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        {
                            "Role",response.Role
                        },
                        {
                            "Email", UserEmail
                        }
                    });

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, response.Role));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                context.Validated(identity);

            }
            else
            {
                context.SetError("Autorization Error", ErrorMessage);
                context.Response.Headers.Add("AuthorizationResponse", new[] { "Failed" });
            }





        }

        // User email adresi ve password doğrumu diye  kontrol eder.
        // Bu alan daha sonra BL taşınacaktır.
        private LoginCO RegisteredEndUserControl(string userEmail, string userPassword)
        {
            AuthenticationService authenticate = new AuthenticationService(new UserRepo(), new TempUserRepo());

            LoginCO response = authenticate.Login(userEmail, userPassword);
            if (response.Status)
            {

                return response;
            }

            ErrorMessage = "Wrong email or password please try again"; //"Kullanici adi veya sifre yanlis";
            return response;
        }

        //User email adresi ve password null mi kontrol eder.
        private bool NullUserEmailPasswordControl(string userName, string password)
        {
            if (userName == null || password == null)
                return true;
            return false;
        }
    }
}