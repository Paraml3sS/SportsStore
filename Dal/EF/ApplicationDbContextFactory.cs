using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dal.EF
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = @"Data Source=DESKTOP-22TA5GA\YBSQL;Initial Catalog=SportStore;Integrated Security=True;App=EntityFramework";
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
