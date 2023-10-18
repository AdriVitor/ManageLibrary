using ManageLibrary_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageLibrary_Infra.Context {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options){}
        public DbSet<Book> Book { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Loan> Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
