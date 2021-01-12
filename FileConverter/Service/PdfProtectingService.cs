using iText.Kernel.Pdf;
using System.IO;
using System.Text;

namespace FileConverter.Service
{
    public class PdfProtectingService
    {
        public string Lock(string filePath, string userPassword, string ownerPassword)
        {
            var newFilePath = CreateNewFilePath(filePath, "-locked");

            var document = new PdfDocument(new PdfReader(filePath), new PdfWriter(newFilePath,
                new WriterProperties().SetStandardEncryption(
                    Encoding.UTF8.GetBytes(userPassword),
                    Encoding.UTF8.GetBytes(ownerPassword),
                    EncryptionConstants.ALLOW_PRINTING,
                    EncryptionConstants.ENCRYPTION_AES_128 | EncryptionConstants.DO_NOT_ENCRYPT_METADATA
                )));
            document.Close();

            return Path.GetFileName(newFilePath);
        }

        public string Unlock(string filePath, string ownerPassword)
        {
            var newFilePath = CreateNewFilePath(filePath, "-unlocked");

            using var document = new PdfDocument(
                new PdfReader(filePath, new ReaderProperties().SetPassword(Encoding.UTF8.GetBytes(ownerPassword))),
                new PdfWriter(newFilePath)
            );
            document.Close();

            return Path.GetFileName(newFilePath);
        }

        private static string CreateNewFilePath(string filePath, string newFileNameAddition)
        {
            var fileDirectory = Path.GetFullPath(Path.GetDirectoryName(filePath) ?? string.Empty);
            var fileExtension = Path.GetExtension(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var newFilePath = Path.Combine(fileDirectory, $"{fileName}{newFileNameAddition}{fileExtension}");
            return newFilePath;
        }
    }
}