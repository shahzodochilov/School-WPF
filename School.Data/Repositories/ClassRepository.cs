using Microsoft.EntityFrameworkCore;
using School.Data.DbContexts;
using School.Data.Interfaces;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Repositories
#pragma warning disable
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _dbo;

        public ClassRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<Class> CreateAsync(Class entity)
        {
            var _class = await _dbo.Classes.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var _class = await _dbo.Classes.FindAsync(id);
            if (_class is not null)
            {
                _dbo.Classes.Remove(_class);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Class> FindeAsync(long id)
        {
            return await _dbo.Classes.FindAsync(id);
        }

        public async Task<Class> FirsOrDefaultAsync(Expression<Func<Class, bool>> expression)
        {
            return await _dbo.Classes.FirstOrDefaultAsync(expression);
        }

        public async Task<Class> UpdateAsync(long id, Class entity)
        {
            entity.Id = id;
            _dbo.Classes.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<Class>> WhereAsync(Expression<Func<Class, bool>> expression)
        {
            return _dbo.Classes.Where(expression);
        }
    }
}
