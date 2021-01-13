using FileConverter.Enums;
using FileConverter.Helpers;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.IO;
using System.Text;
using WordToPDF;

namespace FileConverter.Service
{
    public class ConversionService
    {
        public string Convert(string filePath, ConversionTypes conversionType)
        {
            return conversionType switch
            {
                ConversionTypes.PDF => ConvertToPdf(filePath),
                ConversionTypes.TXT => ConvertToTxt(filePath),
                _ => throw new NotImplementedException()
            };
        }

        private static string ConvertToTxt(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            var strategy = new LocationTextExtractionStrategy();
            if (extension == ".pdf")
            {
                var processed = new StringBuilder();

                var pdfDocument = new PdfDocument(new PdfReader(filePath));

                for (var i = 1; i <= pdfDocument.GetNumberOfPages(); ++i)
                {
                    var page = pdfDocument.GetPage(i);
                    var text = PdfTextExtractor.GetTextFromPage(page, strategy);
                    processed.Append(text);
                }

                var newFilePath = FileHelpers.CreateNewFilePath(filePath, "-converted", ".txt");

                File.WriteAllText(newFilePath, processed.ToString());

                return Path.GetFileName(newFilePath);
            }

            throw new NotSupportedException("This extension is not supported");
        }

        private static string ConvertToPdf(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".doc" || extension == ".docx")
            {
                var newFilePath = FileHelpers.CreateNewFilePath(filePath, "-converted", ".pdf");
                var converter = new Word2Pdf {InputLocation = filePath, OutputLocation = newFilePath};
                converter.Word2PdfCOnversion();
                return Path.GetFileName(newFilePath);
            }

            throw new NotSupportedException("This extension is not supported");
        }
    }
}