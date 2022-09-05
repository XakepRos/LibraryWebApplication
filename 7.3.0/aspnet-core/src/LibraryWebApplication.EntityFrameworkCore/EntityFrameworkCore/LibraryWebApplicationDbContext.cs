using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibraryWebApplication.Authorization.Roles;
using LibraryWebApplication.Authorization.Users;
using LibraryWebApplication.MultiTenancy;
using LibraryWebApplication.Departments;

namespace LibraryWebApplication.EntityFrameworkCore
{
    public class LibraryWebApplicationDbContext : AbpZeroDbContext<Tenant, Role, User, LibraryWebApplicationDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Department> Departments { get; set; }
        public LibraryWebApplicationDbContext(DbContextOptions<LibraryWebApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
