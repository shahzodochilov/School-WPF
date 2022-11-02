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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _dbo;

        public TeacherRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<Teacher> CreateAsync(Teacher entity)
        {
            await _dbo.Teachers.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var teacher = await _dbo.Teachers.FindAsync(id);
            if (teacher is not null) 
            {
                _dbo.Teachers.Remove(teacher);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Teacher> FindeAsync(long id)
        {
            return await _dbo.Teachers.FindAsync(id);
        }

        public async Task<Teacher> FirsOrDefaultAsync(Expression<Func<Teacher, bool>> expression)
        {
            return _dbo.Teachers.FirstOrDefault(expression);
        }

        public async Task<Teacher> UpdateAsync(long id, Teacher entity)
        {
            entity.Id = id;
            _dbo.Teachers.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<Teacher>> WhereAsync(Expression<Func<Teacher, bool>> expression)
        {
            return _dbo.Teachers.Where(expression);
        }
    }
}
