using CSIMedia.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSIMedia.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<EFNumber> Numbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EFNumber>().ToTable("EFNumbers");
        base.OnModelCreating(modelBuilder);
    }
}
