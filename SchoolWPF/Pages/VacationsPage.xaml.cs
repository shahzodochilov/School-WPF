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
    /// Interaction logic for VacationsPage.xaml
    /// </summary>
    public partial class VacationsPage : Page
    {
        private readonly IVacatioRepository vacatioRepository;
        public VacationsPage()
        {
            InitializeComponent();
            this.vacatioRepository = new VacationRepository();
        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var vacation = await vacatioRepository.WhereAsync(x => true);

            dgData.ItemsSource = vacation.ToList();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
