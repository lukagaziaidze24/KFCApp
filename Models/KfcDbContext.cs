using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KFCApp.Models
{
    public class KfcDbContext : DbContext
    {
        public KfcDbContext() : base("name=MySqlConn") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Staff> Staff { get; set; }
    }
}
