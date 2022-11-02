using School.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class PrideOfSchool : Auditable
    {
        public long? PupilId { get; set; }
        public virtual Pupil Pupil { get; set; } = null!;

    }
}
