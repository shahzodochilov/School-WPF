using Microsoft.EntityFrameworkCore;
using School.Data.DbContexts;
using School.Data.Interfaces;
using School.Data.Repositories;
using School.Desktop.Windows.Classes;
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
    /// Interaction logic for ClassesPage.xaml
    /// </summary>
    public partial class ClassesPage : Page
    {
        private readonly IClassService classservice;
        private readonly IClassRepository classrepository;
        private readonly ITeacherRepository teacherRepository;
        public ClassesPage()
        {
            InitializeComponent();
            this.classservice = new ClassService();
            this.classrepository = new ClassRepository();
            this.teacherRepository = new TeacherRepository();
        }
        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = await classservice.WhereAsync();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateClassWindow createClassWindow = new CreateClassWindow();
            createClassWindow.ShowDialog();
        }
        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            var _classViewModel = (ClassViewModel)dgData.SelectedItem;
            var _class = await classrepository.FindeAsync(_classViewModel.Id);
            if(_class is not null)
            {
                UpdateClassWindow updateClassWindow = new UpdateClassWindow();
                updateClassWindow.Id.Text = _class.Id.ToString();
                updateClassWindow.Name.Text = _class.Name.ToString();
                updateClassWindow.TeacherId.SelectedIndex = (await teacherRepository.WhereAsync(x => true)).ToList().FindIndex(x=> x.Id == _class.TeacherId);
                updateClassWindow.PupilsNumber.Text = _class.PupilNumber.ToString();

                updateClassWindow.ShowDialog();
            }
            else MessageBox.Show("Xatolik yuz berdi");
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var _classViewModel = (ClassViewModel)dgData.SelectedItem;
            if(_classViewModel is not null)
            {
                if (await classrepository.DeleteAsync(_classViewModel.Id))
                {
                    MessageBox.Show("O'chirildi");
                }
                else MessageBox.Show("Xatolik yuz berdi!");
            }
            else MessageBox.Show("Sinf topilmadi!");
        }
    }
}
