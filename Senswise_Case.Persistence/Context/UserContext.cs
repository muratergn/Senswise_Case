using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senswise_Case.Domain.Entities;

namespace Senswise_Case.Persistence.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=database;Username=senswise_user;Password=12345;"
            );

        }

        // DbSet örneği
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                      .HasDefaultValueSql("gen_random_uuid()")
                      .ValueGeneratedOnAdd();

                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(u => u.Address)
                      .HasMaxLength(300); 
            });
        }
    }
}
