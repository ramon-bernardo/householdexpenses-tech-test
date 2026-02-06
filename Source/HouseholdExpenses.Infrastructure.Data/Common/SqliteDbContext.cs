using HouseholdExpenses.Infrastructure.Data.Person.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Infrastructure.Data.Common;

public sealed class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)
{
    public DbSet<PeopleModel> Peoples { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PeopleModel>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                  .HasConversion<long>()
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.Age)
                  .HasConversion<long>();

            entity.HasQueryFilter(p => !p.Deleted);

            entity.HasIndex(p => p.Deleted)
                  .HasDatabaseName("IX_people_deleted");
        });
    }
}
