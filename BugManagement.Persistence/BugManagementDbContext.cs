using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using BugManagement.DomainModel;

namespace BugManagement.Persistence
{
    public class BugManagementDbContext:DbContext
    {
        public BugManagementDbContext()
            : base("name=BugManagementDbContext")
         {
            if (!Database.Exists())
            {
                Database.SetInitializer(new InitializerIfDbNotExists());
                Database.Initialize(true);
            }
         }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<BugOperationRecord> BugOperationRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new BugMap());
            modelBuilder.Configurations.Add(new BugOperationRecordMap());
        }
    }

    public class InitializerIfDbNotExists : DropCreateDatabaseAlways<BugManagementDbContext>
    {
        protected override void Seed(BugManagementDbContext context)
        {
            var userA = new User()
                {
                    Id = new Guid("31D75E8C-F5DD-7366-BD78-594F2E12D04E"),
                    FirstName = "UserA",
                    LastName = "UserA",
                    Username = "UserA",
                    Password = "UserA"
                };
            var projectA = new Project()
                {
                    Id = new Guid("E22F89ED-967D-4416-6EDA-96D52C0571A5"),
                    Name = "ProjectA",
                };
            var projectB = new Project()
                {
                    Id = new Guid("FF013E1E-717A-2F83-5B82-EAED1F6F62C2"),
                    Name = "ProjectB",
                };

            var bugA = new Bug()
                {
                    Id = new Guid("84026007-5153-BE14-8165-6BB0CFA60162"),
                    Title = "BugA",
                    Description = "BugA",
                    Status = (int) BugStatus.Opened,
                    ProjectId = new Guid("E22F89ED-967D-4416-6EDA-96D52C0571A5"),
                    AssignerId = new Guid("31D75E8C-F5DD-7366-BD78-594F2E12D04E")
                };
            var bugB = new Bug()
            {
                Id = new Guid("9D3C3E96-5A23-A4AF-FC6B-2BB6D1A6855A"),
                Title = "BugB",
                Description = "BugB",
                Status = (int)BugStatus.Opened,
                ProjectId = new Guid("FF013E1E-717A-2F83-5B82-EAED1F6F62C2"),
                AssignerId = new Guid("31D75E8C-F5DD-7366-BD78-594F2E12D04E")
            };
            var operationRecordA = new BugOperationRecord()
                {
                    Id=new Guid("22593CED-4BB7-A364-E839-D1DE67B44783"),
                    OperateTime = DateTime.Now,
                    Operate = (int)BugOperate.Open,
                    OperaterId = new Guid("31D75E8C-F5DD-7366-BD78-594F2E12D04E"),
                    BugId = new Guid("84026007-5153-BE14-8165-6BB0CFA60162")
                };
            var operationRecordB = new BugOperationRecord()
            {
                Id = new Guid("A8D109E8-E021-9D55-162F-8D7B72F443C3"),
                OperateTime = DateTime.Now,
                Operate = (int)BugOperate.Open,
                OperaterId = new Guid("31D75E8C-F5DD-7366-BD78-594F2E12D04E"),
                BugId = new Guid("9D3C3E96-5A23-A4AF-FC6B-2BB6D1A6855A")
            };
            context.Users.Add(userA);
            context.Projects.Add(projectA);
            context.Projects.Add(projectB);
            context.Bugs.Add(bugA);
            context.Bugs.Add(bugB);
            context.BugOperationRecords.Add(operationRecordA);
            context.BugOperationRecords.Add(operationRecordB);
            context.SaveChanges();
        }
    }

    public class ProjectMap:EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            ToTable("Project");
            HasKey(x => x.Id);
            Property(x => x.Name);
            
        }
    }
    public class BugMap : EntityTypeConfiguration<Bug>
    {
        public BugMap()
        {
            ToTable("Bug");
            HasKey(x => x.Id);
            Property(x => x.Title);
            Property(x => x.Description);
            Property(x => x.Status);
            HasRequired(x => x.Project).WithMany(x => x.Bugs).HasForeignKey(x => x.ProjectId).WillCascadeOnDelete(false);
            HasRequired(x => x.Assigner).WithMany(x => x.Bugs).HasForeignKey(x => x.AssignerId).WillCascadeOnDelete(false);
        }
    }

    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Username);
            Property(x => x.FirstName);
            Property(x => x.LastName);
            Property(x => x.Password);
        }
    }
    public class BugOperationRecordMap:EntityTypeConfiguration<BugOperationRecord>
    {
        public BugOperationRecordMap()
        {
            ToTable("BugOperationRecord");
            HasKey(x => x.Id);
            Property(x => x.OperateTime);
            Property(x => x.Operate);
            HasRequired(x => x.Operater).WithMany(x => x.BugOperationRecords).HasForeignKey(x => x.OperaterId).WillCascadeOnDelete(false);
            HasRequired(x => x.Bug).WithMany(x => x.OperationRecords).HasForeignKey(x => x.BugId).WillCascadeOnDelete(false); 

        }
    }
}
