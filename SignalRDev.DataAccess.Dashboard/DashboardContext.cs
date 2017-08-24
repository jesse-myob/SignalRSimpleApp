using SignalRDev.DataAccess.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDev.DataAccess.Models;

namespace SignalRDev.DataAccess.Dashboard
{
    public class DashboardContext : DbContext, IDashboardContext
    {
        public DashboardContext()
        {

        }

        public DashboardContext(string connectionString) : base(connectionString)
        {

        }

        public System.Data.Entity.IDbSet<UserLog> CoopbaseUsers { get; set; }

        IDbSet<TEntity> IDashboardContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
