using System.Windows;
using System.Windows.Input;

namespace FileConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GridMainBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonConverter_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();

        }

        private void ButtonProtection_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();

        }
    }
}
