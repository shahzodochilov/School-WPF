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
#pragma warning disable
{
    /// <summary>
    /// Interaction logic for UpdateClassWindow.xaml
    /// </summary>
    public partial class UpdateClassWindow : Window
    {
        private readonly IClassRepository classRepository;
        private readonly ITeacherRepository teacherRepository;
        public UpdateClassWindow()
        {
            InitializeComponent();
            this.classRepository = new ClassRepository();
            this.teacherRepository = new TeacherRepository();
            GetAllTeacherData();
        }
        
        private async void GetAllTeacherData()
        {
            DataContext = (await teacherRepository.WhereAsync(x => true)).ToList();
        }

        private async void Save_click(object sender, RoutedEventArgs e)
        {
            Class _class = new Class
            {
                Id = long.Parse(Id.Text),
                Name = Name.Text,
                TeacherId = long.Parse(TeacherId.SelectedValue.ToString()),
                PupilNumber = short.Parse(PupilsNumber.Text.ToString())
            };
            await classRepository.UpdateAsync(_class.Id, _class);

            this.Close();
        }
    }
}
