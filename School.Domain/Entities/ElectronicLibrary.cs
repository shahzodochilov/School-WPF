using School.Domain.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class ElectronicLibrary : Auditable
    {
        public string BookName { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;
    }
}
