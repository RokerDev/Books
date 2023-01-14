using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Books.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<BooksContext>
    {
        /// <summary>
        /// help application create a derived DbContext
        /// instance during the design time which will help with migrations
        /// </summary>
        /// <param name="args"></param>
        /// <returns>new instance of RepositoryContext with provided options</returns>
        public BooksContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<BooksContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            return new BooksContext(builder.Options);
        }
    }
}

