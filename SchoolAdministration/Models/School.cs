using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class School
{
    private readonly List<Student> _students = [];

    private readonly List<Course> _courses = [];

    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();
}
