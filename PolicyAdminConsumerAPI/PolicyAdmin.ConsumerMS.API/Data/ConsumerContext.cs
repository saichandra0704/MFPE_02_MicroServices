using Microsoft.EntityFrameworkCore;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Data
{
    public class ConsumerContext : DbContext
    {
        public ConsumerContext()
        {
        }

        public ConsumerContext(DbContextOptions<ConsumerContext> options)
            : base(options)
        {
        }

        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessMaster> BusinessesMaster { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyMaster> PropertiesMaster { get; set; }
    }
}
