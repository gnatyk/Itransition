using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using Itransition.Models;
using Owin.Security.Providers.GitHub;

namespace Itransition
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(GlobalDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            app.UseTwitterAuthentication(
               consumerKey: "WmJ74E6tbRvlxJNpG5R9nv8OX",
               consumerSecret: "6cf8PRFePg1Jo7XOr0o2Z4d1Pygoyx3Yh2vfB3ngHJaWf947E2");
            app.UseVkontakteAuthentication(
                "4669640",
                "c454LTT6mKtCB2PLC6Ye",
               "email,audio"
                );
            app.UseFacebookAuthentication(
               appId: "656921181085770",
               appSecret: "6ea581ca8ec2dfbd4745ce0e882f8867");
            
            app.UseGitHubAuthentication(
        clientId: "6092677a626276246f4c",
        clientSecret: "1776c092e5fe0679aee4c8fc5aa8166e5334c037");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "000000000000000.apps.googleusercontent.com",
            //    ClientSecret = "000000000000000"
            //});
        }
    }
}