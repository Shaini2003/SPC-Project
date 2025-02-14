using Microsoft.EntityFrameworkCore;
using Project.Models.Entities;
using SPC.API.Models;

namespace Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        //{

        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ManufacturingPlant> ManufacturingPlants { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Pharmacy> pharmacies { get; set; }
        public DbSet<Staff> staff { get; set; }
        public DbSet<Warehouse> warehouses { get; set; }
        

    }
}
