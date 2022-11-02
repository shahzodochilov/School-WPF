using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Common.Interfaces
{
    public interface ISearchable<T>
    {
        Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression);
    }
}
