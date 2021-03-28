using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace SpaceTests
{
    public class TestContext : DbContext
    {
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Payment> Payments { get; set; }


        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
    }
}
