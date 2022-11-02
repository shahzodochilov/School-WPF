using School.Data.Interfaces;
using School.Data.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace School.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        private readonly IWorkerRepository workerRepository;
        public WorkersPage()
        {
            InitializeComponent();
            this.workerRepository = new WorkerRepository();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = (await workerRepository.WhereAsync(x => true)).ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
