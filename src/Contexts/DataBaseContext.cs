using cmsapplication.src.Contexts.Configurations;
using cmsapplication.src.Models;
using Microsoft.EntityFrameworkCore;

namespace cmsapplication.src.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Post> posts { get; set; } 
    public DbSet<Comments> comments { get; set; } 
    public DbSet<Person> persons { get; set; } 

    public DataBaseContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    } 
}