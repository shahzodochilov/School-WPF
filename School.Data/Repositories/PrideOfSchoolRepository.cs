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
    public class PrideOfSchoolRepository : IPrideOfSchoolRepository
    {
        private readonly AppDbContext _dbo;

        public PrideOfSchoolRepository()
        {
            this._dbo = new AppDbContext();
        }

        public async Task<PrideOfSchool> CreateAsync(PrideOfSchool entity)
        {
            var prideOfSchool = await _dbo.PrideOfSchools.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var item = await _dbo.PrideOfSchools.FindAsync(id);
            if(item is not null) 
            {
                _dbo.PrideOfSchools.Remove(item);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<PrideOfSchool> FindeAsync(long id)
        {
            return await _dbo.PrideOfSchools.FindAsync(id);
        }

        public async Task<PrideOfSchool> FirsOrDefaultAsync(Expression<Func<PrideOfSchool, bool>> expression)
        {
            return _dbo.PrideOfSchools.FirstOrDefault(expression);
        }

        public async Task<PrideOfSchool> UpdateAsync(long id, PrideOfSchool entity)
        {
            entity.Id = id;
            _dbo.PrideOfSchools.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<PrideOfSchool>> WhereAsync(Expression<Func<PrideOfSchool, bool>> expression)
        {
            return _dbo.PrideOfSchools.Where(expression);
        }
    }
}
