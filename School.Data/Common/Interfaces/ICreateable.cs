using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Common.Interfaces
{
    public interface ICreateable<T>
    {
        Task<T> CreateAsync(T entity);
    }
}
