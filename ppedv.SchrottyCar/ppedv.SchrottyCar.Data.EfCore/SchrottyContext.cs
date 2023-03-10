using Microsoft.EntityFrameworkCore;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Data.EfCore
{
    public class SchrottyContext : DbContext
    {
        private readonly string conString;

        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public SchrottyContext(string _constring)
        {
            conString = _constring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(x => x.BillingAddress).WithMany(x => x.BillingOrders);
            modelBuilder.Entity<Order>().HasOne(x => x.DeliveryAddress).WithMany(x => x.DeliveryOrders);

            modelBuilder.Entity<Order>().HasMany(x => x.OrderItems).WithOne(x => x.Order).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Car>().Ignore(x => x.KW);
        }
    }
}