using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Common.Interfaces
{
    public interface IFindable<T>
    {
        Task<T> FindeAsync(long id);

        Task<T> FirsOrDefaultAsync(Expression<Func<T, bool>> expression);
    }
}
