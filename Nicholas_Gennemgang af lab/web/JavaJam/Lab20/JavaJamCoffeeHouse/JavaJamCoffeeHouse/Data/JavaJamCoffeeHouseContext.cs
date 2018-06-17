using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JavaJamCoffeeHouse.Models
{
    public class JavaJamCoffeeHouseContext : DbContext
    {
        public JavaJamCoffeeHouseContext (DbContextOptions<JavaJamCoffeeHouseContext> options)
            : base(options)
        {
        }

        public DbSet<JavaJamCoffeeHouse.Models.Jobs> Jobs { get; set; }
    }
}
