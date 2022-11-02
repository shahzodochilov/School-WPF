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

namespace School.Desktop.Windows.Pupils
{
    /// <summary>
    /// Interaction logic for CreatePupilWindow.xaml
    /// </summary>
    public partial class CreatePupilWindow : Window
    {
        private readonly IClassRepository classRepository;
        private readonly IPupilRepository pupilRepository;

        public List<Class> Classes { get; set; } = null!;
        public CreatePupilWindow()
        {
            InitializeComponent();
            this.classRepository = new ClassRepository();
            this.pupilRepository = new PupilRepository();
            GetClass();
        }

        private async void GetClass()
        {
            Classes = (await classRepository.WhereAsync(x => true)).ToList();
            DataContext = Classes;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Pupil pupil = new Pupil
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                PhoneNumber = PhoneNumber.Text,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                ClassId = long.Parse(ClassId.SelectedValue.ToString()),
                Gender = _Gender.Text == "Erkak" ? Gender.Male : Gender.Female
            };
            await pupilRepository.CreateAsync(pupil);

            this.Close();
        }
    }
}
