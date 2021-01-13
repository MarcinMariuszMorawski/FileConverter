using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FileConverter.Enums;
using FileConverter.Helpers;
using FileConverter.Service;

namespace FileConverter.Controls
{
    public partial class ConverterControl : UserControl
    {
        public ConverterControl()
        {
            InitializeComponent();
        }


        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBlockFile.Text))
            {
                TextBlockInfo.Text = "Please load file first";
                return;
            }

            if (string.IsNullOrEmpty(ComboBoxFileTypes.Text))
            {
                TextBlockInfo.Text = "Please choose destination file type";
                return;
            }

            try
            {
                var pickedConversionType =
                    ComboBoxFileTypes.Items[ComboBoxFileTypes.SelectedIndex] is ConversionTypes type
                        ? type
                        : ConversionTypes.None;

                var conversionService = new ConversionService();
                var fileName = conversionService.Convert(TextBlockFile.Text, pickedConversionType);
                TextBlockInfo.Text = $"Successfully converted file as {fileName}";
            }
            catch (Exception exception)
            {
                TextBlockInfo.Text = $"Error while converting file: {exception.Message}";
            }
        }

        private void MainPanel_Drop(object sender, DragEventArgs e)
        {
            TextBlockInfo.Text = "";
            TextBlockFile.Text = "";
            ComboBoxFileTypes.SelectedIndex = -1;
            ComboBoxFileTypes.ItemsSource = null;


            try
            {
                if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    return;
                }

                var filePath = ((string[]) e.Data.GetData(DataFormats.FileDrop))?[0];
                var extension = Path.GetExtension(filePath) ?? "";

                var availableExtensionToConvert = extension.GetAvailableConversionTypes();

                if (availableExtensionToConvert.Any())
                {
                    ComboBoxFileTypes.ItemsSource = availableExtensionToConvert;
                    ComboBoxFileTypes.SelectedIndex = 0;
                    TextBlockFile.Text = filePath;
                }
                else
                {
                    TextBlockInfo.Text = "It is not supported file";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while loading file: {exception.Message}");
            }
        }

        private void ComboBoxFileTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockInfo.Text = "";
        }
    }
}