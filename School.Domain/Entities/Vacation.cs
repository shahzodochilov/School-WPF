using School.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Vacation : Auditable
    {
        public string Name { get; set; } = string.Empty;

        public double Salary { get; set; }
        
        public short Number { get; set; }
    }
}
