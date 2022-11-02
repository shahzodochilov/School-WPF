using School.Desktop.Pages;
using School.Desktop.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SchoolWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MinWidth = 1200;
            this.MinHeight = 600;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new TeachersPage();
        }

        private void Pupil_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new PupilsPage();
        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new ClassesPage();
        }

        private void PrideOfSchool_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new PrideOfSchoolesPage();
        }

        private void VeteranOfSchool_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new VeteranOfSchoolPage();
        }

        private void Telegram_Click(object sender, RoutedEventArgs e)
        {
            string strCmdText;
            strCmdText = "/K  explorer.exe http://t.me/shahzodochilov & exit";
            Process.Start("CMD.exe", strCmdText);
        }

        private void WebSite_Click(object sender, RoutedEventArgs e)
        {
            string strCmdText;
            strCmdText = "/K  explorer.exe http://www.google.com & exit";
            Process.Start("CMD.exe", strCmdText);
        }

        private void Instagram_Click(object sender, RoutedEventArgs e)
        {
            string strCmdText;
            strCmdText = "/K  explorer.exe https://instagram.com/shakhzod_ochilov_tuit & exit";
            Process.Start("CMD.exe", strCmdText);
        }

        private void Vacation_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new VacationsPage();
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new WorkersPage();
        }

        private void ElectronicLibrary_Click(object sender, RoutedEventArgs e)
        {
            FrPagesNavigation.Content = new ElectronicLibrariesPage();
        }
    }
}
