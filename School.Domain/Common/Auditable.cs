using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Common
{
    public class Auditable : BaseEntity
    {
        public DateOnly CreatedDate { get; set; }
    }
}
    