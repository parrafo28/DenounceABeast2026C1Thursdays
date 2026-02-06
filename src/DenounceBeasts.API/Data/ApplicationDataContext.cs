using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }
    }
}
