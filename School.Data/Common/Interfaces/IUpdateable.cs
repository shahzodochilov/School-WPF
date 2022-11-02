using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Common.Interfaces
{
    public interface IUpdateable<T>
    {
        Task<T> UpdateAsync(long id, T entity);
    }
}
