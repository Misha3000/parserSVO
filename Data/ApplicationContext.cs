using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationContext : DbContext
{
    public DbSet<Events> Events { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
    { 
        Database.EnsureCreated();
    }
    
}