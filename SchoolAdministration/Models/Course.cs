namespace SchoolAdministration.Models;

internal sealed class Course
{
    private readonly List<ClassRoom> _classRooms = [];

    public required Guid Id { get; set; }

    public string? CourseNumber { get; set; }

    public required string Name { get; set; }

    public IReadOnlyList<ClassRoom> ClassRooms => _classRooms;
}