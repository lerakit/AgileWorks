using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class AppDbContext : DbContext
{
    public DbSet<Request> Requests { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}