using System.Windows;
using System.Windows.Controls;
using FileConverter.Enums;
using MaterialDesignThemes.Wpf;

namespace FileConverter.Controls
{
    public partial class PdfProtectionControl : UserControl
    {
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
            if (string.IsNullOrEmpty(TextBoxPassword.Password))
            {
                IconExclamation.Visibility = Visibility.Visible;
            }
        }

        private void MainPanel_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            TextBlockFiles.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))?[0];

        }
        private void TextBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            IconExclamation.Visibility = Visibility.Hidden;
        }
    }
}