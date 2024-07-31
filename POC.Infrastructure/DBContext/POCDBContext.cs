using Microsoft.EntityFrameworkCore;
using POC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace POC.Infrastructure.DBContext
{
    public class POCDBContext : DbContext
    {
        public POCDBContext(DbContextOptions<POCDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
