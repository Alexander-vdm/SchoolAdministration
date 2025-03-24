using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class ExamResult
{
    public ExamResult(Course course, Student student, ExamResultEnum examResultEnum)
    {
        Course = course;
        Student = student;
        Result = examResultEnum;
    }

    public Course Course { get; set; }

    public Student Student { get; set; }

    public ExamResultEnum Result { get; set; }
}
