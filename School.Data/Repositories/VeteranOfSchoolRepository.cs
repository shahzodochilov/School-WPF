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
    public class VeteranOfSchoolRepository : IVeteranOfSchoolRepository
    {
        private readonly AppDbContext _dbo;

        public VeteranOfSchoolRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<VeteranOfSchool> CreateAsync(VeteranOfSchool entity)
        {
            await  _dbo.VeteranOfSchools.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var veteranOfSchool = await _dbo.VeteranOfSchools.FindAsync(id);
            if(veteranOfSchool is not null)
            {
                _dbo.VeteranOfSchools.Remove(veteranOfSchool);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<VeteranOfSchool> FindeAsync(long id)
        {
            return await _dbo.VeteranOfSchools.FindAsync(id);
        }

        public async Task<VeteranOfSchool> FirsOrDefaultAsync(Expression<Func<VeteranOfSchool, bool>> expression)
        {
            return await _dbo.VeteranOfSchools.FirstOrDefaultAsync(expression);
        }

        public async Task<VeteranOfSchool> UpdateAsync(long id, VeteranOfSchool entity)
        {
            entity.Id = id;
            _dbo.VeteranOfSchools.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<VeteranOfSchool>> WhereAsync(Expression<Func<VeteranOfSchool, bool>> expression)
        {
            return _dbo.VeteranOfSchools.Where(expression);
        }
    }
}
