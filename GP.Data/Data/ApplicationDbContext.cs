using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GP.Data.Entities;

namespace GP.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> User { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingCart>()
                .HasIndex(c => new { c.UserID, c.ProductID })
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.UserID);

            modelBuilder.Entity<Review>()
                .HasIndex(r => r.ProductID);

            modelBuilder.Entity<ShoppingCart>()
                .HasIndex(sc => sc.UserID);
        }
    }
}
