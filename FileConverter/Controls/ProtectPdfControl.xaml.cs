using System.Windows;
using System.Windows.Controls;

namespace FileConverter.Controls
{
    public partial class ProtectPdfControl : UserControl
    {
        public ProtectPdfControl()
        {
            InitializeComponent();
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