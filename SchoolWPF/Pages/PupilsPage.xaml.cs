using School.Data.DbContexts;
using School.Data.Interfaces;
using School.Data.Repositories;
using School.Desktop.Windows.Pupils;
using School.Domain.Entities;
using School.Service.Interfaces;
using School.Service.Services;
using School.Service.ViewModels;
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
    /// Interaction logic for PupilsPage.xaml
    /// </summary>
    public partial class PupilsPage : Page
    {
        private readonly IPupilService pupilService;
        private readonly IPupilRepository pupilRepository;
        private readonly IClassRepository classRepository;

        public PupilsPage()
        {
            InitializeComponent();
            this.pupilService = new PupilService();
            this.pupilRepository = new PupilRepository();
            this.classRepository = new ClassRepository();
        }

        public async void DataGrid_Loaded(object sender, RoutedEventArgs e) 
        {
            dgData.ItemsSource = await pupilService.WhereAsync();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreatePupilWindow createPupilWindow = new CreatePupilWindow();
            createPupilWindow.ShowDialog();
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            var pupilViewModel = (PupilViewModel)dgData.SelectedItem;
            var pupil = await pupilRepository.FindeAsync(pupilViewModel.Id);
            if (pupil is not null)
            {
                UpdatePupilWindow updatePupilWindow = new UpdatePupilWindow();
                updatePupilWindow.Id.Text = pupil.Id.ToString();
                updatePupilWindow.FirstName.Text = pupil.FirstName.ToString();
                updatePupilWindow.LastName.Text = pupil.LastName.ToString();
                updatePupilWindow.PhoneNumber.Text = pupil.PhoneNumber.ToString();
                updatePupilWindow.ClassId.SelectedIndex = (await classRepository.WhereAsync(x => true)).ToList().FindIndex(x => x.Id == pupil.ClassId);
                updatePupilWindow._Gender.Text = pupil.Gender == Domain.Enums.Gender.Male ? "Erkak" : "Ayol";

                updatePupilWindow.ShowDialog();
            }
            else MessageBox.Show("Xatolik Yuz berdi!");
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var pupil = (PupilViewModel)dgData.SelectedItem;
            if(pupil is not null)
            {
                if (await pupilRepository.DeleteAsync(pupil.Id)) 
                {
                    MessageBox.Show("O'chirildi!");
                }
                else MessageBox.Show("Xatolik Yuz berdi!");
            }
            else MessageBox.Show("Xatolik Yuz berdi!");
        }
    }
}
