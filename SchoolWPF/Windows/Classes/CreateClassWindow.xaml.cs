using School.Data.Interfaces;
using School.Data.Repositories;
using School.Domain.Entities;
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

namespace School.Desktop.Windows.Classes
{
    /// <summary>
    /// Interaction logic for CreateClassWindow.xaml
    /// </summary>
    public partial class CreateClassWindow : Window
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IClassRepository classRepository;
        public CreateClassWindow()
        {
            InitializeComponent();
            this.teacherRepository = new TeacherRepository();
            this.classRepository = new ClassRepository();
            GetTeachers();
        }


        private async void GetTeachers()
        {
            DataContext = (await teacherRepository.WhereAsync(x => true)).ToList();
        }

        private async void Save_click(object sender, RoutedEventArgs e)
        {
            Class _class = new Class
            {
                Name = Name.Text,
                TeacherId = long.Parse(Teacher.SelectedValue.ToString()),
                PupilNumber = short.Parse(PupilsNumber.Text)
            };
            await classRepository.CreateAsync(_class);
            this.Close();
        }
    }
}
