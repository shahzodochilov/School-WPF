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
    public class WorkerRepository : IWorkerRepository
    {
        private readonly AppDbContext _dbo;

        public WorkerRepository()
        {
            this._dbo = new AppDbContext();
        }
        public async Task<Worker> CreateAsync(Worker entity)
        {
            await _dbo.Workers.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var worker = await _dbo.Workers.FindAsync(id);
            if(worker is not null)
            {
                 _dbo.Workers.Remove(worker);
                await _dbo.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task<Worker> FindeAsync(long id)
        {
            return await _dbo.Workers.FindAsync(id);
        }

        public async Task<Worker> FirsOrDefaultAsync(Expression<Func<Worker, bool>> expression)
        {
            return await _dbo.Workers.FirstOrDefaultAsync(expression);
        }

        public async Task<Worker> UpdateAsync(long id, Worker entity)
        {
            entity.Id = id;
            _dbo.Workers.Update(entity);
            await _dbo.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<Worker>> WhereAsync(Expression<Func<Worker, bool>> expression)
        {
            return _dbo.Workers.Where(expression);
        }
    }
}
