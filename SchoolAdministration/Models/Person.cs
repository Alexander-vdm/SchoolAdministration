namespace SchoolAdministration.Models;

internal class Person
{
    public required string FirstName { get; set; }

    public required string FamilyName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {FamilyName}";
    }
}
