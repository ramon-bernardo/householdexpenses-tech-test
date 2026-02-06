namespace HouseholdExpenses.Infrastructure.Data.Person.Models;

public sealed class PeopleModel
{
    public uint Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public uint Age { get; private set; }

    public bool Deleted { get; private set; }

    private PeopleModel() { }
}
