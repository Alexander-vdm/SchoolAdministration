using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class Course
{
    private readonly List<Student> _students = [];

    private readonly List<ExamResult> _examResults = [];

    public required Guid Id { get; set; }

    public string? CourseNumber { get; set; }

    public required string Name { get; set; }

    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public IReadOnlyList<ExamResult> ExamResults => _examResults.AsReadOnly();

    public void AddStudent(Student student)
    {
        if (!_students.Any(x => x.StudentNumber == student.StudentNumber))
        {
            _students.Add(student);
        }
    }

    public void ReportExamResult(Student student, ExamResultEnum examResultEnum)
    {
        var examResult = new ExamResult(this, student, examResultEnum);
        _examResults.Add(examResult);
    }

    public override string ToString()
    {
        return Name;
    }
}


