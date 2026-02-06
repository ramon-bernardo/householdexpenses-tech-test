using System.Text.Json.Serialization;

namespace HouseholdExpenses.Domain.Categories.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoryPurpose
{
    Both,
    Expense,
    Income
}
