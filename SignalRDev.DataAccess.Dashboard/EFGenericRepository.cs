using SignalRDev.DataAccess.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.DataAccess.Dashboard
{
    public class EFGenericRepository<T> : IRepository<T>
        where T : class
    {
        protected IDashboardContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public EFGenericRepository(IDashboardContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            this.DbSet = this.Context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;
            else
                this.DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void DeleteById(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
                this.Delete(entity);
        }

        public T Attach(T entity)
        {
            return this.Context.Set<T>().Attach(entity);
        }

        public void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
