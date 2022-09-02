using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.EntityFrameworkCore
{
    public static class LibraryWebApplicationDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibraryWebApplicationDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibraryWebApplicationDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
