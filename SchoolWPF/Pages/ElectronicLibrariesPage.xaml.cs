using School.Data.Interfaces;
using School.Data.Repositories;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

namespace School.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for ElectronicLibrary.xaml
    /// </summary>
    public partial class ElectronicLibrariesPage : Page
    {
        private readonly IElectronicLibraryRepository electronicLibraryRepository;
        public ElectronicLibrariesPage()
        {
            InitializeComponent();
            this.electronicLibraryRepository = new ElectronicLibraryRepository();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = (await electronicLibraryRepository.WhereAsync(x => true)).ToList();
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            var book = (ElectronicLibrary)dgData.SelectedItem;
            if (book is not null)
            {
                string strCmdText;
                strCmdText = $"/K CD {book.FilePath} && explorer.exe {book.BookName} & exit\n";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }
            else MessageBox.Show("Fayl topilmadi");
        }
    }
}
