using School.Data.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Interfaces
{
    public interface IGenericRepository<T>:
        ICreateable<T>, ISearchable<T>,
        IUpdateable<T>, IFindable<T>,
        IDeleteable<T>
    {
    }
}
