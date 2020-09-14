using Microsoft.EntityFrameworkCore;
using SampleService.Infrastructure.Models;

namespace SampleService.Infrastructure
{
    public class SampleDbContext: DbContext
    {
        
        public DbSet<Models.Data> Data { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) 
        { 

        }   
    }
}