using Discont.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discont.Grpc.Data;


public class DiscountContext : DbContext
{

    public DbSet<Coupon> Coupons { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName ="Name1", Description = "Desc1", Amount=100}
            );
    }
}
