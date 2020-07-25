using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RecapProject1.Entities;

namespace RecapProject1
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        // Ayrıca bir mapleme yapmadıysan Product entitiy ismi Products ise dbdeki adına karşılık gelir. Direk bağlar.

        public DbSet<Category> Categories { get; set; }
    }
}
