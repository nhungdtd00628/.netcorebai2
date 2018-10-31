using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class MyDB : DbContext
    {
        public MyDB(DbContextOptions<MyDB> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
