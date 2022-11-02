using School.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class VeteranOfSchool : Auditable
    {   
        public long? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; } = null!;
     
    }
}
