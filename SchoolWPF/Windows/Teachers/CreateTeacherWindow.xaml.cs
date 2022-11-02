using School.Data.Interfaces;
using School.Data.Repositories;
using School.Domain.Entities;
using School.Domain.Enums;
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

namespace School.Desktop.Windows.Teachers
{
    /// <summary>
    /// Interaction logic for CreateTeacherWindow.xaml
    /// </summary>
    public partial class CreateTeacherWindow : Window
    {
        private readonly ITeacherRepository teacherRepository;
        public CreateTeacherWindow()
        {
            InitializeComponent();
            this.teacherRepository = new TeacherRepository();
        }

        private async void Save_click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher
            {
                FirstName = FirsName.Text,
                LastName = LastName.Text,
                PhoneNumber = PhoneNumber.Text,
                Salary = double.Parse(Salary.Text),
                Gender = _Gender.Text == "Erkak" ? Gender.Male : Gender.Female,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };
            await teacherRepository.CreateAsync(teacher);
            this.Close();
        }
    }
}
