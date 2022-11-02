using Microsoft.EntityFrameworkCore;
using School.Data.DbContexts;
using School.Desktop.Windows.Teachers;
using School.Domain.Entities;
using School.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using School.Data.Repositories;
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
using School.Data.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace School.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        private readonly ITeacherRepository teacherRepositor;
        public TeachersPage()
        {
            InitializeComponent();
            this.teacherRepositor = new TeacherRepository();
        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var teachers = (await teacherRepositor.WhereAsync(x=>true)).ToList();

            dgData.ItemsSource = teachers;
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var teacher = (Teacher)dgData.SelectedItem;
            if (teacher is not null) 
            {
                UpdateTeacherWindow updateTeacherWindow = new UpdateTeacherWindow();
                updateTeacherWindow.FirsName.Text = teacher.FirstName;
                updateTeacherWindow.LastName.Text = teacher.LastName;
                updateTeacherWindow.PhoneNumber.Text = teacher.PhoneNumber;
                updateTeacherWindow.Salary.Text = teacher.Salary.ToString();
                updateTeacherWindow._Gender.Text = teacher.Gender == Gender.Male ? "Erkak" : "Ayol";
                updateTeacherWindow.Id.Text = teacher.Id.ToString();

                updateTeacherWindow.ShowDialog();
            }
            else MessageBox.Show("Xatolik yuz berdi");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var teacher = (Teacher)dgData.SelectedItem;
            if (teacher is not null)
            {
                long id = teacher.Id;
                teacherRepositor.DeleteAsync(id);
                MessageBox.Show("Successful");
            }
            else MessageBox.Show("Xatolik yuz berdi");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateTeacherWindow createTeacherWindow = new CreateTeacherWindow();
            createTeacherWindow.ShowDialog();
        }
    }
}
