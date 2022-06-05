using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ICS.Project.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IcsProjectDbContext>
    {
        public IcsProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<IcsProjectDbContext> builder = new();
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = IcsProject;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");

            return new IcsProjectDbContext(builder.Options);
        }
    }
}
