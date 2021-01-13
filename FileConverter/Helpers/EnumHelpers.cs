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
                },
                ".docx" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                ".doc" => new List<ConversionTypes>
                {
                    ConversionTypes.PDF
                },
                _ => new List<ConversionTypes>()
            };
        }
    }
}