using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
    
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
                await context.SaveChangesAsync();
        }
    }
}
