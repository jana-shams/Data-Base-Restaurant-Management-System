using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Data
{
    public class RestaurantManagementContext : DbContext
    {
        public RestaurantManagementContext(DbContextOptions<RestaurantManagementContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<KitchenTicket> KitchenTickets { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PromotionDetail> PromotionDetails { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.MenuItemID });

            modelBuilder.Entity<PromotionDetail>()
                 .HasKey(pd => new { pd.PromotionID, pd.MenuItemID });

            // Configure relationships (explicitly where needed)

            // Customer to Order (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);


            // Order to OrderDetail (One-to-Many)
            modelBuilder.Entity<OrderDetail>()
               .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID)
                 .OnDelete(DeleteBehavior.Cascade);

            // MenuItem to OrderDetail (One-to-Many)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.MenuItem)
                .WithMany(mi => mi.OrderDetails)
                .HasForeignKey(od => od.MenuItemID)
                .OnDelete(DeleteBehavior.Cascade);
            // Promotion to PromotionDetail (One-to-Many)
            modelBuilder.Entity<PromotionDetail>()
                .HasOne(pd => pd.Promotion)
                .WithMany(p => p.PromotionDetails)
                .HasForeignKey(pd => pd.PromotionID)
                .OnDelete(DeleteBehavior.Cascade);
            // MenuItem to PromotionDetail (One-to-Many)
            modelBuilder.Entity<PromotionDetail>()
                .HasOne(pd => pd.MenuItem)
                .WithMany(mi => mi.PromotionDetails)
                .HasForeignKey(pd => pd.MenuItemID)
                .OnDelete(DeleteBehavior.Cascade);

            // Order to Payment (One-to-Many)
            modelBuilder.Entity<Payment>()
              .HasOne(p => p.Order)
               .WithMany(o => o.Payments)
               .HasForeignKey(p => p.OrderID)
               .OnDelete(DeleteBehavior.Cascade);

            //Payment to Receipt (One-to-One)
            modelBuilder.Entity<Receipt>()
               .HasOne(r => r.Payment)
               .WithOne(p => p.Receipt)
               .HasForeignKey<Receipt>(r => r.PaymentID)
               .OnDelete(DeleteBehavior.Cascade);

            //Order to KitchenTicket (One-to-One)
            modelBuilder.Entity<KitchenTicket>()
                .HasOne(kt => kt.Order)
                .WithOne(o => o.KitchenTicket)
                .HasForeignKey<KitchenTicket>(kt => kt.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            //Order to Delivery (One-to-One)
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Order)
               .WithOne(o => o.Delivery)
               .HasForeignKey<Delivery>(d => d.OrderID)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}