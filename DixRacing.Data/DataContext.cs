using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DixRacing.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace DixRacing.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }






    }
}