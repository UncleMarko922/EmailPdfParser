using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace EmailPdfParser
{
    class PdfParser
    {
        public static string GetText(Byte[] pdfData)
        {
            string pdfText = string.Empty;

            using (PdfDocument document = PdfDocument.Open(pdfData))
            {
                int pageCount = document.NumberOfPages;

                for (int currPage = 1; currPage <= pageCount; currPage++)
                {
                    Page page = document.GetPage(currPage);

                    pdfText += page.Text;
                }
            }

            return pdfText;
        }
    }
}
