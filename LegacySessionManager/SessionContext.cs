using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace LegacySessionManager
{
    [DbConfigurationType(typeof(SessionDbConfiguration))]
    class SessionContext : DbContext
    {
        public SessionContext()
            : base(ApplicationConfiguration.SessionDatabase)
        {
        }

        public virtual DbSet<SessionState> SessionStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionState>()
                .Property(e => e.SessionId)
                .IsUnicode(false);
        }
    }

    class SessionDbConfiguration : DbConfiguration
    {
        public SessionDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);

            //SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
            //SetExecutionStrategy("System.Data.SqlClient", 
            //    () => new System.Data.Entity.Infrastructure.SqlConnectionFactory()) ;
        }
    }


}
