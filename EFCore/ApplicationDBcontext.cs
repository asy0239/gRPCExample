using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{

    public class ApplicationDBcontext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("mirero");
            // 장바구니 항목 엔티티의 복합 기본 키 설정
            modelBuilder.Entity<ShoppingCartItem>()
                .HasKey(sc => new { sc.UserId, sc.ProductId });

            // User와 ShoppingCartItem 사이의 관계 설정
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sc => sc.User)
                .WithMany()
                .HasForeignKey(sc => sc.UserId);

            // Product와 ShoppingCartItem 사이의 관계 설정
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sc => sc.Product)
                .WithMany()
                .HasForeignKey(sc => sc.ProductId);
        }
    }
}