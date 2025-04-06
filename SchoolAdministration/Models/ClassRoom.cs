using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal class ClassRoom
{
    private readonly List<Student> _students = [];
    private readonly List<ExamResult> _examResults = [];

    public required Guid Id { get; set; }

    public required ushort Level { get; set; }

    public required char Code { get; set; }

    public required  Course Course { get; set; }

    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public IReadOnlyList<ExamResult> ExamResults => _examResults.AsReadOnly();
}
