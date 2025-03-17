using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using femnear;

namespace femnear
{
    public class femContext : DbContext
    {
        public DbSet<Datapersonen> Datapersonen { get; set; }


        public femContext(DbContextOptions<femContext> options) : base(options)

        {

        }
    }
}
