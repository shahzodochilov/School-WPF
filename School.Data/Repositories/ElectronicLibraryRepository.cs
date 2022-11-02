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
    public class ElectronicLibraryRepository : IElectronicLibraryRepository
    {
        private readonly AppDbContext _dbo;
        public ElectronicLibraryRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<ElectronicLibrary> CreateAsync(ElectronicLibrary entity)
        {
            await _dbo.ElectronicLibraries.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var electronicLibrary = await _dbo.ElectronicLibraries.FindAsync(id);
            if(electronicLibrary is not null) 
            {
                _dbo.ElectronicLibraries.Remove(electronicLibrary);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ElectronicLibrary> FindeAsync(long id)
        {
            var electronicLibrary = await _dbo.ElectronicLibraries.FindAsync(id);
            if (electronicLibrary is not null)
            {
                return electronicLibrary;
            }

            else return new ElectronicLibrary();
        }

        public async Task<ElectronicLibrary> FirsOrDefaultAsync(Expression<Func<ElectronicLibrary, bool>> expression)
        {
            var electronicLibrary = await _dbo.ElectronicLibraries.FirstOrDefaultAsync(expression);
            if (electronicLibrary is not null) return electronicLibrary;
            else return new ElectronicLibrary();
        }

        public async Task<ElectronicLibrary> UpdateAsync(long id, ElectronicLibrary entity)
        {
            entity.Id = id;
            _dbo.ElectronicLibraries.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<ElectronicLibrary>> WhereAsync(Expression<Func<ElectronicLibrary, bool>> expression)
        {
            return _dbo.ElectronicLibraries.Where(expression);
        }
    }
}
