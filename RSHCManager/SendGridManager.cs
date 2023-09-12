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
using Newtonsoft.Json;

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

        public async Task configSendGridTemplateasync(SendGridTemplateMessage message, SendGridTemplateType type)
        {
            string SendGridApiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(SendGridApiKey);

            string TemplateId;

            //msg.SetFrom(new EmailAddress("EZaslavsky@rshc-law.com", "RSHC"));
            //msg.AddTo(new EmailAddress(message.Destination));
           

            switch (type)
            {
                case SendGridTemplateType.ConfirmYourAccount:
                    TemplateId = "d-6f8e51678a3c43f0a516b94b7612ad8a";
                    break;
                case SendGridTemplateType.ConfirmEmail:
                    TemplateId = "d-7644de9f97d14e139a4744b457ac4495";              
                    break;
                case SendGridTemplateType.ResetPassword:
                    TemplateId = "d-ed4ac927a2f5459fb966cde0a5895b80";             
                    break;
                default :
                    TemplateId = "";
                    Trace.TraceError("Failed to locate an email template " + message.Destination);
                    await Task.FromResult(0);
                    break;
            }

            var msg = MailHelper.CreateSingleTemplateEmail(new EmailAddress("EZaslavsky@rshc-law.com", "RSHC"), new EmailAddress(message.Destination), TemplateId, message);

            //  string strJson = JsonSerializer.Serialize<SendGridTemplateIdentityMessage>(message);

            var response = await client.SendEmailAsync(msg);



            if (!response.IsSuccessStatusCode)
            {
                Trace.TraceError("Failed to send an email to " + message.Destination);
                await Task.FromResult(0);
            }
        }
    }


    public class SendGridTemplateMessage
    {
        public string CallbackUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Destination { get; set; }
        public string Subject { get; set; }
    }
}
