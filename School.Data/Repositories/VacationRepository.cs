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
{
    public class VacationRepository : IVacatioRepository
    {
        private readonly AppDbContext _dbo;
        public VacationRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<Vacation> CreateAsync(Vacation entity)
        {
            await _dbo.Vacations.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var vacation = await _dbo.Vacations.FindAsync(id);
            if(vacation is not null)
            {
                _dbo.Vacations.Remove(vacation);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Vacation> FindeAsync(long id)
        {
            var vacation = await _dbo.Vacations.FindAsync(id);
            if(vacation is not null)
            {
                return vacation;
            }
            else return new Vacation();
        }

        public async Task<Vacation> FirsOrDefaultAsync(Expression<Func<Vacation, bool>> expression)
        {
            var vacation = await _dbo.Vacations.FirstOrDefaultAsync(expression);
            if(vacation is not null)
            {
                return vacation;
            }
            return new Vacation();
        }

        public async Task<Vacation> UpdateAsync(long id, Vacation entity)
        {
            entity.Id = id;
            _dbo.Vacations.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<Vacation>> WhereAsync(Expression<Func<Vacation, bool>> expression)
        {
            return _dbo.Vacations.Where(expression);
        }
    }
}
