using FileConverter.Controls;
using FileConverter.Enums;
using System.Windows;
using System.Windows.Input;

namespace FileConverter
{
    public partial class MainWindow : Window
    {
        private MenuTypes MenuType { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MenuType = MenuTypes.Converter;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GridMainBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonConverter_Click(object sender, RoutedEventArgs e)
        {
            if (MenuType == MenuTypes.Converter) return;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new ConverterControl());
            MenuType = MenuTypes.Converter;
        }

        private void ButtonProtection_Click(object sender, RoutedEventArgs e)
        {
            if (MenuType == MenuTypes.LockPdf) return;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PdfProtectionControl(PdfProtectionTControlTypes.Lock));
            MenuType = MenuTypes.LockPdf;
        }

        private void ButtonUnlock_Click(object sender, RoutedEventArgs e)
        {
            if (MenuType == MenuTypes.UnlockPdf) return;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PdfProtectionControl(PdfProtectionTControlTypes.Unlock));
            MenuType = MenuTypes.UnlockPdf;
        }
    }
}