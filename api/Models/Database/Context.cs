using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Moe.CMP.Models.Database
{
	public partial class Context : DbContext
    {

    	modelBuilder.Entity<LikeList>(entity =>
            {
                entity.HasKey(e => e.SN);
                entity.Property(e => e.SN).HasColumnName("SN").ValueGeneratedOnAdd();
                entity.Property(e => e.UserID).IsRequired().HasMaxLength(20);
                entity.Property(e => e.ProductNo).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Account).IsRequired().HasMaxLength(20);
                entity.Property(e => e.TotalFee).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.TotalAmount).IsRequired().HasPrecision(18, 2);
                
                entity.HasOne(e => e.User)
                      .WithMany(u => u.LikeLists)
                      .HasForeignKey(e => e.UserID);
                
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.LikeLists)
                      .HasForeignKey(e => e.ProductNo);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.No);
                entity.Property(e => e.No).HasColumnName("No").ValueGeneratedOnAdd();
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.FeeRate).IsRequired().HasPrecision(5, 4);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).HasMaxLength(20);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Account).IsRequired().HasMaxLength(20);
                

            });
    }
}
