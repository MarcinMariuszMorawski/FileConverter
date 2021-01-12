using FileConverter.Enums;
using System.Collections.Generic;

namespace FileConverter.Helpers
{
    public static class EnumHelpers
    {
        public static List<ConversionTypes> GetAvailableConversionTypes(this string extension)
        {
            return extension.ToLower().Trim() switch
            {
                ".pdf" => new List<ConversionTypes>
                {
                    ConversionTypes.Word,
                    ConversionTypes.Excel,
                    ConversionTypes.PowerPoint,
                    ConversionTypes.JPG,
                },
                ".docx" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".doc" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".xlsx" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".xls" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".pptx" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".ppt" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".jpg" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".jpeg" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                _ => new List<ConversionTypes>()
            };
        }
    }
}