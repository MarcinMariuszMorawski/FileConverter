using iText.Kernel.Pdf;
using System.IO;
using System.Text;
using FileConverter.Helpers;

namespace FileConverter.Service
{
    public class PdfProtectingService
    {
        public string Lock(string filePath, string userPassword, string ownerPassword)
        {
            var newFilePath = FileHelpers.CreateNewFilePath(filePath, "-locked", ".pdf");

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
            var newFilePath = FileHelpers.CreateNewFilePath(filePath, "-unlocked", ".pdf");

            using var document = new PdfDocument(
                new PdfReader(filePath, new ReaderProperties().SetPassword(Encoding.UTF8.GetBytes(ownerPassword))),
                new PdfWriter(newFilePath)
            );
            document.Close();

            return Path.GetFileName(newFilePath);
        }

        
    }
}