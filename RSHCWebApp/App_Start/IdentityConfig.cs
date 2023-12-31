﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using RSHCEnteties.DataAccessLayer;
using RSHCWebApp.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using RSHCEnteties;
using System.Web.Mvc;

namespace RSHCWebApp
{
    public class EmailService : IIdentityMessageService
    {
        private async Task configSendGridasync(IdentityMessage message)
        {
            // var apiKey = ConfigurationManager.AppSettings["SendGridKey"];
            string SendGridApiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(SendGridApiKey);
            var from = new EmailAddress("service.web@rshc-law.com", "Riley Safer Holmes & Cancila");
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination);
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);


            // Send the email.
            var response = await client.SendEmailAsync(msg);

           
            if (!response.IsSuccessStatusCode)
            {
                Trace.TraceError("Failed to send an email to " + message.Destination);
                await Task.FromResult(0);
            }
        }
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);

        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Twilio Begin
            //var accountSid = ConfigurationManager.AppSettings["TwilioSMSAccountIdentification"];
            //var authToken = ConfigurationManager.AppSettings["TwilioSMSAccountPassword"];
            //var fromNumber = ConfigurationManager.AppSettings["TwilioSMSAccountFrom"];

            string accountSid = Environment.GetEnvironmentVariable("TwilioSMSAccountIdentification");
            string authToken = Environment.GetEnvironmentVariable("TwilioSMSAccountPassword");
            string fromNumber = Environment.GetEnvironmentVariable("TwilioSMSAccountFrom");


            try
            {

                TwilioClient.Init(accountSid, authToken);

                MessageResource result = MessageResource.Create(
                new PhoneNumber(message.Destination),
                from: new PhoneNumber(fromNumber),
                body: message.Body
                );

                //Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
                Trace.TraceInformation(result.Status.ToString());

                //Twilio doesn't currently have an async API, so return success.
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                //  Block of code to handle errorsChange your account settings
                Trace.TraceError($"Failed to send message: {e}");
                return Task.FromException(e);
            }
            
           
            // Twilio End
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            // ToDo Test this one
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<RSHCDatabaseContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;


             
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
