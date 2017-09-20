using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    public class EfGenericRepository<T> : IRepository<T> where T: class
    {
        public EfGenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }
        
        public IQueryable<T> All
        {
            get
            {
                return this.DbSet;
            }
                
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
