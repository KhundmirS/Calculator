using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Repository.Models;


namespace CalculatorApp.Data
    {
        public class ApplicationDbContext : IdentityDbContext<User>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Calculation> Calculations { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configure entity filters, indexes, relationships, etc.

                modelBuilder.Entity<Calculation>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Expression)
                          .IsRequired()
                          .HasMaxLength(256);
                    entity.Property(e => e.Result)
                          .IsRequired()
                          .HasMaxLength(256);
                    entity.Property(e => e.TimeStamp)
                          .IsRequired();
                    entity.Property(e => e.UserId)
                          .IsRequired();
                });
            }
        }
    }

