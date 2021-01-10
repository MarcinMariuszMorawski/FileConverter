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
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                IconExclamation.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            IconExclamation.Visibility = Visibility.Hidden;
        }
    }
}
