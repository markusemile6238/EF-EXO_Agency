using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AgDbContext>
    {
        public AgDbContext CreateDbContext(string[] args)
        {            
            var optionsBuilder = new DbContextOptionsBuilder<AgDbContext>();
            optionsBuilder.UseSqlServer("Server= GOS-VDI509\\TFTIC; Initial Catalog=ExoAgency; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");

            return new AgDbContext(optionsBuilder.Options);
        }
    }
}
