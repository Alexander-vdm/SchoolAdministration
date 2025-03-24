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
        if (!_courses.Any(x => x.CourseNumber == exam.CourseNumber))
        {
            _courses.Add(exam);
        }
    }

    public void ReceiveExamResult(Guid courseNumber, ExamResultEnum examResultEnum)
    {
        var course = _courses.Single(x => x.CourseNumber == courseNumber);
        var examResult = new ExamResult(course, this, examResultEnum);
        _examResults.Add(examResult);
    }

    public Course? TryGetCourse(Guid courseNumber)
    {
        return _courses.SingleOrDefault(x => x.CourseNumber == courseNumber);
    }
}
