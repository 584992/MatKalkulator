using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KaloriKalkulator
{
    public partial class FoodContext : DbContext
    {
        public FoodContext()
        {
        }

        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Foods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-40ROT9A;Database=Food;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Item)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("item");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
