using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace EmailPdfParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email();

            FileAttachment fileAttachment = email.GetEmail("resume");

            string pdfText = PdfParser.GetText(fileAttachment.Content);

            Console.WriteLine(pdfText);
            Console.Read();
                      
        }
    }
}
