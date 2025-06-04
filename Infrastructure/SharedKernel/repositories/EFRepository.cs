using Core.SharedKernel.Entity;
using Core.SharedKernel.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SharedKernel.repositories
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id)
                         ?? throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with Id {id} not found.");
            
            entity.MarkDeleted();
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
            => _dbSet.FirstOrDefault(e => e.Id == id);

        public IList<T> GetAll()
            => _dbSet.ToList();
    }
}
