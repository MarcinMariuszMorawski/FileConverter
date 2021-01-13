using FileConverter.Enums;
using FileConverter.Helpers;
using System;
using System.IO;
using WordToPDF;

namespace FileConverter.Service
{
    public class ConversionService
    {
        public string Convert(string filePath, ConversionTypes conversionType)
        {
            return conversionType switch
            {
                ConversionTypes.PDF => ConvertToWPdf(filePath),
                ConversionTypes.Word => ConvertToWord(filePath),
                _ => throw new NotImplementedException()
            };
        }

        private static string ConvertToWord(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".pdf")
            {
                return "not implemented";
            }

            throw new NotSupportedException("This extension is not supported");
        }

        private static string ConvertToWPdf(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".doc" || extension == ".docx")
            {
                var newFilePath = FileHelpers.CreateNewFilePath(filePath, "-converted", ".pdf");
                var converter = new Word2Pdf { InputLocation = filePath, OutputLocation = newFilePath };
                converter.Word2PdfCOnversion();
                return Path.GetFileName(newFilePath);
            }

            throw new NotSupportedException("This extension is not supported");
        }
    }
}