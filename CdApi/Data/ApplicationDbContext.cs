using Microsoft.EntityFrameworkCore;
using CdApi.Models;

namespace CdApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CD> CDs { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}