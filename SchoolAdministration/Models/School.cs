using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class School
{
    private readonly List<Student> _students = [];

    private readonly List<Course> _courses = [];

    public School(List<Course> courses)
    {
        _courses = courses;
    }

    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();

    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public Student InscribeStudent(Person person, Guid courseNumber)
    {
        var course = _courses.Single(x => x.CourseNumber == courseNumber);

        var student = new Student(Guid.NewGuid())
        {
            FamilyName = person.FamilyName,
            FirstName = person.FirstName
        };

        student.AddCourse(course);
        course.AddStudent(student);

        _students.Add(student);

        return student;
    }

    public void InschribeToCourse(Guid studentNumber, Guid courseNumber)
    {
        var student = _students.Single(x => x.StudentNumber == studentNumber);
        var course = _courses.Single(x => x.CourseNumber == courseNumber);

        student.AddCourse(course);
        course.AddStudent(student);
    }

    public void TrySetExamResult(Guid studentNumber, Guid courseNumber, ExamResultEnum examResultEnum)
    {
        var student = _students.Single(x => x.StudentNumber == studentNumber);
        var course = student.TryGetCourse(courseNumber);
        if (course is null)
        {
            var existingExam = _courses.Single(x => x.CourseNumber == courseNumber);
            Console.WriteLine($"Could not find exam {existingExam} for student {student}");
            return;
        }

        var examResult = new ExamResult(course, student, examResultEnum);

        student.ReceiveExamResult(courseNumber, examResultEnum);
        course.ReportExamResult(student, examResultEnum);
    }
}
