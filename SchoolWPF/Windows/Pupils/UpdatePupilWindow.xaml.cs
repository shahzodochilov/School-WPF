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
#pragma warning disable 
{
    /// <summary>
    /// Interaction logic for UpdatePupilWindow.xaml
    /// </summary>
    public partial class UpdatePupilWindow : Window
    {
        private readonly IPupilRepository pupilRepository;
        private readonly IClassRepository classRepository;
        public UpdatePupilWindow()
        {
            InitializeComponent();
            this.pupilRepository = new PupilRepository();
            this.classRepository = new ClassRepository();
            GetAllClassData();
        }

        private async void GetAllClassData()
        {
            var classes = await classRepository.WhereAsync(x => true);
            DataContext = classes.ToList();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Pupil pupil = new Pupil
            {
                Id = long.Parse(Id.Text),
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                PhoneNumber = PhoneNumber.Text,
                ClassId = long.Parse(ClassId.SelectedValue.ToString()),
                Gender = _Gender.Text == "Erkak" ? Gender.Male : Gender.Female,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };
            await pupilRepository.UpdateAsync(pupil.Id, pupil);

            this.Close();
        }
    }
}
