using Microsoft.EntityFrameworkCore.Design;

namespace ISB.CLWater.Service.Context
{
    public class CLWaterContextFactory : IDesignTimeDbContextFactory<CLWaterContext>
    {
        public CLWaterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CLWaterContext>();
            optionsBuilder.UseSqlServer("Data Source=DEVFSBMSQ004;Initial Catalog=CLWaterDB_02112024;MultipleActiveResultSets=true;Integrated Security=SSPI;TrustServerCertificate=True;");
            return new CLWaterContext(optionsBuilder.Options);
        }
    }
}
