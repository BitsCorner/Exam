using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ExamEntities _dbContext;

        public Repository(ExamEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(T t)
        {
            try
            {
                _dbContext.Set<T>().Add(t);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0; 
                throw;
            }
        }

        public async Task<int> RemoveAsync(T t)
        {
            _dbContext.Entry(t).State = EntityState.Deleted;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _dbContext.Set<T>().Where(match).ToListAsync();
        }
    }
}
