using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private WebDbContext db;
        private DbSet<T> entities;

        public Repository(WebDbContext db)
        {
            this.db = db;
            entities = db.Set<T>();
        }

        public async Task Add(T item)
        {
            entities.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await entities.FindAsync(id);
            if (entity != null)
            {
                entities.Remove(entity);
                await db.SaveChangesAsync();
            } 
        }

        public async Task<T> Get(int id)
        {
            var item = await entities.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
