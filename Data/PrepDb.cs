using ColourAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ColourAPI.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }
        }

        private static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("Applying migrations...");

            context.Database.Migrate();

            System.Console.WriteLine("Migrations applied.");

            if (!context.Colour.Any())
            {
                System.Console.WriteLine("Data not present, seeding database.");

                context.Colour.AddRange(
                    new Colour
                    {
                        ColourName = "Red"
                    },
                    new Colour
                    {
                        ColourName = "Blue"
                    },
                    new Colour
                    {
                        ColourName = "Green"
                    }
                );

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Data already present, not seeding.");
            }
        }
    }
}