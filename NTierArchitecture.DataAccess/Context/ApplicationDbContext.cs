using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
         public DbSet<Product> Products { get; set; }
         public DbSet<Category> Categories { get; set; }
         public DbSet<Order> Orders { get; set; }
         public DbSet<OrderDetail> OrderDetail { get; set; }
         public DbSet<Supplier> Supplier { get; set; }
         public DbSet<Employee> Employees { get; set; }
         public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MERT\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               modelBuilder.Entity<OrderDetail>()
                   .HasKey(o => new {o.OrderID,o.ProductID });

               modelBuilder.Entity<OrderDetail>().Ignore(o => o.Id);
        }
    }
}
