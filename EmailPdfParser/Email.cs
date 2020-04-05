
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailPdfParser
{
    class Email
    {
        private ExchangeService service;

        public string user = Environment.GetEnvironmentVariable("OutlookUser");
        public string pass = Environment.GetEnvironmentVariable("OutlookPass");


        public Email()
        {
            service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

            service.Credentials = new WebCredentials(user, pass);

            service.AutodiscoverUrl(user);
        }



        public FileAttachment GetEmail(string subject)
        {
            FindItemsResults<Item> findResults = service.FindItems(
               WellKnownFolderName.Inbox,
               new ItemView(10));

            FileAttachment pdf;

            foreach (Item item in findResults.Items)
            {
                Console.WriteLine(item.Subject);
                if (item.Subject.Contains(subject))
                {
                    item.Load();
                    if (item.HasAttachments)
                    {
                        foreach (var i in item.Attachments)
                        {
                            // Cast i as FileAttachment type
                            FileAttachment fileAttachment = i as FileAttachment;
                            fileAttachment.Load();
                            pdf = fileAttachment;
                            return pdf;
                        }
                    }
                }
            }

            return null;
        }

    }
}
