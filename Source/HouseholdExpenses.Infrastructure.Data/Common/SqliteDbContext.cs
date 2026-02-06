using HouseholdExpenses.Infrastructure.Data.Person.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Infrastructure.Data.Common;

public sealed class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)
{
    public DbSet<PeopleModel> Peoples { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PeopleModel>((entity) =>
        {
            entity.HasKey(model => model.Id);

            entity.Property(model => model.Id)
                .HasConversion<long>()
                .ValueGeneratedOnAdd();

            entity.Property(model => model.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(model => model.Age)
                .IsRequired()
                .HasConversion<long>();

            entity.Property(model => model.Deleted)
                .HasDefaultValue(false);

            entity.HasQueryFilter(model => !model.Deleted);

            entity.HasIndex(model => model.Deleted)
                .HasDatabaseName("IX_people_deleted");
        });
    }
}
