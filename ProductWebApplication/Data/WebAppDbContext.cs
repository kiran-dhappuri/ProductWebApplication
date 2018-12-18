using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductWebApplication.Models.Custom;

namespace ProductWebApplication.Data
{
    /* NOTES
     * =========================================================================================
     * To create a new migrations:
     * > Add-Migration -context WebAppDbContext WebAppDbContextMigrations
     *
     * To update databse with new db changes run following command:
     * > Update-Database -context WebAppDbContext
     * > 
     */
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
