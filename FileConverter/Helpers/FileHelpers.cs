using System.IO;

namespace FileConverter.Helpers
{
    public static class FileHelpers
    {
        public static string CreateNewFilePath(string filePath, string newFileNameAddition, string newFileExtension)
        {
            var fileDirectory = Path.GetFullPath(Path.GetDirectoryName(filePath) ?? string.Empty);
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var newFilePath = Path.Combine(fileDirectory, $"{fileName}{newFileNameAddition}{newFileExtension}");
            return newFilePath;
        }
    }
}