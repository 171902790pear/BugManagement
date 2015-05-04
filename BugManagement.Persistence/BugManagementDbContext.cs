using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using BugManagement.DomainModel;

namespace BugManagement.Persistence
{
    public class BugManagementDbContext:DbContext
    {
        public BugManagementDbContext()
            : base("name=BugManagementDbContext")
         {
            Database.SetInitializer(new Initializer());
         }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<BugManagementDbContext>
    {
        protected override void Seed(BugManagementDbContext context)
        {

        }
    }

    public class ProjectMap:EntityTypeConfiguration<Project>
    {
        
    }
}
