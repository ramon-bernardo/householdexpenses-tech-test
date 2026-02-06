using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Infrastructure.Data.Categories.Models;
using HouseholdExpenses.Infrastructure.Data.People.Models;

namespace HouseholdExpenses.Infrastructure.Data.Common;

public sealed class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)
{
    public DbSet<PersonModel> People { get; init; }

    public DbSet<CategoryModel> Categories { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonModel>((entity) =>
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

        modelBuilder.Entity<CategoryModel>((entity) =>
        {
            entity.HasKey(model => model.Id);

            entity.Property(model => model.Id)
                .HasConversion<long>()
                .ValueGeneratedOnAdd();

            entity.Property(model => model.Description)
                .IsRequired()
                .HasMaxLength(400);

            entity.Property(model => model.Purpose)
                .IsRequired()
                .HasConversion(
                    model => model.ToString().ToUpper(),
                    text => Enum.Parse<CategoryPurposeModel>(text, true)
                )
                .HasMaxLength(8);
        });
    }
}
