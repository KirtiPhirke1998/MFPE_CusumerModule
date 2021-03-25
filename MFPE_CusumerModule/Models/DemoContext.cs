using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CusumerModule.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> op) : base(op) { }

        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<PropertyMaster> PropertyMasters { get; set; }
        public virtual DbSet<BusinessMaster> BusinessMasters { get; set; }

    }
}
