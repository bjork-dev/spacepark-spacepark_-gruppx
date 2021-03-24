using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class SpaceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = SpacePark; Integrated Security = True;");
    //      optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SpacePark;Integrated Security=True;");
        }

        public virtual DbSet<Parking> Parkings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
