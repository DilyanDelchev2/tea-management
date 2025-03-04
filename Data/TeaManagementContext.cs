using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeaManagmentSystem2.Models;

namespace TeaManagmentSystem2.Data
{
    public class TeaManagementContext : DbContext
    {
        public TeaManagementContext(DbContextOptions<TeaManagementContext> options) : base(options) { }

        public DbSet<Tea> Teas { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
