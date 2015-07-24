using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Repository.FileManipulations;
using GirlsAgency.Repository.Repositories;
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "XML Files (.xml)|*.xml|Archive Files (*.zip)|*.zip|All Files (.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };


            // Call the ShowDialog method to show the dialog box.
            var userClickedOK = openDialog.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                // Open the selected file to read.
                FilePathTextBox.Text = openDialog.FileName;
                uploadButton.IsEnabled = true;
            }
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var extention = FilePathTextBox.Text.Split('.')[1];
                var fileName = System.IO.Path.GetFileName(this.FilePathTextBox.Text);
                switch (extention)
                {
                    case "xml":
                        XML.Read(this.FilePathTextBox.Text); break;
                    case "xls":
                    case "xlsx":
                        Excel.GetRecords(this.FilePathTextBox.Text, this.comboBox.Text); break;
                    case "zip":
                    {
                        ZipFile.ExtractToDirectory(this.FilePathTextBox.Text, "../");
                        Excel.GetRecords("../Importer.xlsx", this.comboBox.Text);
                        File.Delete("../Importer.xlsx");
                    }
                        break;
                    default:
                        throw new ArgumentException("Lainar malyk");
                }
            }
            catch (Exception kArgumentExceptione)
            {
                MessageBox.Show("BUM " + kArgumentExceptione.Message, "KOR MAIKA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            


        }
    }
}
