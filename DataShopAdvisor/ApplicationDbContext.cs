using DataShopAdvisor.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataShopAdvisor
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Place> Places { set; get; }

        public DbSet<Comment> Comments { set; get; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}