using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.ViewModels
{
    public class ClassViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Tutor { get; set; } = string.Empty;

        public short PupilsNumber { get; set; }
    }
}
