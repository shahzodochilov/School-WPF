using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.ViewModels
{
    public class PrideOfSchoolViewModel
    {
        public long Id { get; set; }

        public string PupilName { get; set; } = string.Empty;

        public DateOnly CreatedDate { get; set; }
    }
}
