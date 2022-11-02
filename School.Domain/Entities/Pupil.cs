using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Pupil : Person
    {
        public long? ClassId { get; set; }
        public virtual Class Class { get; set; } = null!;

    }
}
