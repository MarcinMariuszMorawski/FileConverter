using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FileConverter.Enums;
using FileConverter.Service;
using MaterialDesignThemes.Wpf;

namespace FileConverter.Controls
{
    public partial class PdfProtectionControl : UserControl
    {
        private string FileName { get; set; } = "";
        private readonly PdfProtectionTControlTypes _pdfProtectionTControlType;

        public PdfProtectionControl(PdfProtectionTControlTypes pdfProtectionTControlType)
        {
            InitializeComponent();
            _pdfProtectionTControlType = pdfProtectionTControlType;

            if (pdfProtectionTControlType == PdfProtectionTControlTypes.Unlock)
            {
                ButtonProtect.Content = "UNLOCK";
                IconLockUnlock.Kind = PackIconKind.LockOpenVariant;
            }
        }

        private void ButtonProtect_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBlockFile.Text))
            {
                TextBlockInfo.Text = "Please load a PDF file";
                return;
            }

            if (string.IsNullOrWhiteSpace(TextBoxPassword.Password))
            {
                IconExclamation.Visibility = Visibility.Visible;
                return;
            }

            var pdfProtectingService = new PdfProtectingService();

            try
            {
                if (_pdfProtectionTControlType == PdfProtectionTControlTypes.Lock)
                {
                    var fileName = pdfProtectingService.Lock(TextBlockFile.Text, TextBoxPassword.Password,
                        TextBoxPassword.Password);
                    TextBlockInfo.Text = $"Successfully created locked PDF as {fileName}.";
                }
                else
                {
                    var fileName = pdfProtectingService.Unlock(TextBlockFile.Text, TextBoxPassword.Password);
                    TextBlockInfo.Text = $"Successfully created locked PDF as {fileName}.";
                }
            }
            catch (Exception exception)
            {
                TextBlockInfo.Text = $"Error while processing file: {exception.Message}";
            }
        }

        private void MainPanel_Drop(object sender, DragEventArgs e)
        {
            TextBlockInfo.Text = "";
            TextBlockFile.Text = "";

            try
            {
                if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    return;
                }

                var filePath = ((string[]) e.Data.GetData(DataFormats.FileDrop))?[0];
                var extension = Path.GetExtension(filePath) ?? "";

                if (extension.ToLower().Equals(".pdf"))
                {
                    TextBlockFile.Text = filePath;
                }
                else
                {
                    TextBlockInfo.Text = "It is not a PDF file";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while loading file: {exception.Message}");
            }
        }

        private void TextBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            IconExclamation.Visibility = Visibility.Hidden;
        }
    }
}