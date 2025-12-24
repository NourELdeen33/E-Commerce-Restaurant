

using E_Commerce.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var allLst = await _dbset.AsNoTracking().ToListAsync();
            return allLst;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            return entity;
        }

        public  async Task SaveChangesAsync()
        {
          await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _context.SaveChanges();

        }
    }
}
