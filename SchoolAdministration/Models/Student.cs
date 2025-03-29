using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class Student : Person
{
    private readonly List<Course> _courses = [];
    private readonly List<ExamResult> _examResults = [];

    public Student(Guid studentNumber)
    {
        StudentNumber = studentNumber;
    }

    public Guid StudentNumber { get; set; }

    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();

    public IReadOnlyList<ExamResult> ExamResults => _examResults.AsReadOnly();

    public void AddCourse(Course exam)
    {
        if (!_courses.Any(x => x.Id == exam.Id))
        {
            _courses.Add(exam);
        }
    }

    public void ReceiveExamResult(Guid courseId, ExamResultEnum examResultEnum)
    {
        var course = _courses.Single(x => x.Id == courseId);
        var examResult = new ExamResult(course, this, examResultEnum);
        _examResults.Add(examResult);
    }

    public Course? TryGetCourse(Guid courseId)
    {
        return _courses.SingleOrDefault(x => x.Id == courseId);
    }
}
