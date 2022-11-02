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
    public class PupilRepository : IPupilRepository
    {
        private readonly AppDbContext _dbo;

        public PupilRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<Pupil> CreateAsync(Pupil entity)
        {
            await _dbo.Pupils.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var pupil = await _dbo.Pupils.FindAsync(id);
            if (pupil is not null)
            {
                _dbo.Pupils.Remove(pupil);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return true;
        }

        public async Task<Pupil> FindeAsync(long id)
        {
            return await _dbo.Pupils.FindAsync(id);
        }

        public async Task<Pupil> FirsOrDefaultAsync(Expression<Func<Pupil, bool>> expression)
        {
            return await _dbo.Pupils.FirstOrDefaultAsync(expression);
        }

        public async Task<Pupil> UpdateAsync(long id, Pupil entity)
        {
            entity.Id = id;
            _dbo.Pupils.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<Pupil>> WhereAsync(Expression<Func<Pupil, bool>> expression)
        {
            return _dbo.Pupils.Where(expression);
        }
    }
}
