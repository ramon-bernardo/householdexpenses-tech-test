namespace HouseholdExpenses.Domain.Person.Entities;

public sealed class People
{
    public uint Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public uint Age { get; private set; }

    public bool Deleted { get; private set; }

    private People() { }

    private People(string name, uint age)
    {
        Name = name;
        Age = age;
        Deleted = false;
    }

    public static People Create(string name, uint age)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Name is required."); // DomainException
        }

        if (name.Length > 200)
        {
            throw new Exception("Name max length is 200.");
        }

        return new People(name, age);
    }

    public void Update(string name, uint age)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Name is required.");
        }

        if (name.Length > 200)
        {
            throw new Exception("Name max length is 200.");
        }

        Name = name;
        Age = age;
    }

    public void Delete()
    {
        if (Deleted)
        {
            throw new Exception("Already deleted.");
        }

        Deleted = true;
    }
}
