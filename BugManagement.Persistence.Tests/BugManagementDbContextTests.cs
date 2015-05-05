using NUnit.Framework;

namespace BugManagement.Persistence.Tests
{
    [TestFixture]
    public class BugManagementDbContextTests
    {
        [Test]
        public void Call_dbContext_should_create_new_if_db_not_exists()
        {
            var context=new BugManagementDbContext();
            Assert.IsTrue(context.Database.Exists());
            context.Dispose();
        }
    }
}
