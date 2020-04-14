using ColourAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Data 
{
    public class ColourContext : DbContext 
    {
        public ColourContext(DbContextOptions<ColourContext> options) : base(options)
        {
        }

        public DbSet<Colour> Colour { get; set; }
    }
}