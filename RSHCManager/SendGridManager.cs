using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Linq.Expressions;

namespace RSHCManager
{
    public enum SendGridTemplateType
    {
        ResetPassword,
        ConfirmEmail,
        ConfirmYourAccount
    }
    public class SendGridManager
    {
        public SendGridManager() { }

        public async Task configSendGridTemplateasync(SendGridTemplateIdentityMessage message, SendGridTemplateType type)
        {
            string SendGridApiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(SendGridApiKey);

            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("EZaslavsky@rshc-law.com", "RSHC"));
            msg.AddTo(new EmailAddress(message.Destination));


            switch (type)
            {
                case SendGridTemplateType.ConfirmYourAccount:
                    msg.SetTemplateId("d-6f8e51678a3c43f0a516b94b7612ad8a");
                    message.Subject = "Confirm your registration";
                    break;
                case SendGridTemplateType.ConfirmEmail:
                    msg.SetTemplateId("d-7644de9f97d14e139a4744b457ac4495");
                    message.Subject = "Confirm your Email";
                    break;
                case SendGridTemplateType.ResetPassword:
                    msg.SetTemplateId("d-ed4ac927a2f5459fb966cde0a5895b80");
                    message.Subject = "Reset Password";
                    break;
                default :
                    Trace.TraceError("Failed to locate an email template " + message.Destination);
                    await Task.FromResult(0);
                    break;
            }


            var response = await client.SendEmailAsync(msg);



            if (!response.IsSuccessStatusCode)
            {
                Trace.TraceError("Failed to send an email to " + message.Destination);
                await Task.FromResult(0);
            }
        }
    }


    public class SendGridTemplateIdentityMessage : IdentityMessage
    {
        public string CallbackUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
