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

namespace RSHCManager
{
    public class SendGridManager
    {
        public SendGridManager() { }

        public async Task configSendGridTemplateasync(SendGridTemplateIdentityMessage message)
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("EZaslavsky@rshc-law.com", "RSHC"));
            msg.AddTo(new EmailAddress(message.Destination));
            msg.SetTemplateId("d-6f8e51678a3c43f0a516b94b7612ad8a");

            msg.SetTemplateData(message);
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
        public string Confirmation_url { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
