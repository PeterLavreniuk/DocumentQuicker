using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DocumentQuicker.DataProvider
{
    public class DocumentQuickerContextFactory : IDesignTimeDbContextFactory<DocumentQuickerContext>
    {
        public DocumentQuickerContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"..//DocumentQuicker.Api//"))
                        .AddJsonFile("appsettings.Development.json")
                        .Build();
            var connectionString = configuration.GetConnectionString("Database");
            
            var optionsBuilder = new DbContextOptionsBuilder<DocumentQuickerContext>();
            optionsBuilder.UseMySQL(connectionString);

            return new DocumentQuickerContext(optionsBuilder.Options);
        }
    }
}