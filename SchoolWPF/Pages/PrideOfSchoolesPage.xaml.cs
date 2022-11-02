using School.Service.Interfaces;
using School.Service.Services;
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
    /// Interaction logic for PrideOfSchoolesPage.xaml
    /// </summary>
    public partial class PrideOfSchoolesPage : Page
    {
        private readonly IPrideOfSchoolService prideOfSchoolService;
        public PrideOfSchoolesPage()
        {
            InitializeComponent();
            this.prideOfSchoolService = new PrideOfSchoolService();
        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = await prideOfSchoolService.WhereAsync();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
