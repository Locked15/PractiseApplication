using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PractiseApplication.Views.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для PathSelection.xaml
    /// </summary>
    public partial class PathSelection : Window
    {
        public string FullPath { get; private set; }

        public PathSelection()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) =>
                FullPath = pathInput.Text;

        private void openExplorer_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
