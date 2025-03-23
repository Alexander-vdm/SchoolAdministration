namespace SchoolAdministration.Models;

internal class School
{
    private readonly List<Student> _students = [];

    private readonly List<Exam> _exams = [];

    public School(List<Exam> exams)
    {
        _exams = exams;
    }

    public IReadOnlyList<Exam> Exams => _exams.AsReadOnly();

    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public Student InscribeStudent(Person person, Guid examNumber)
    {
        var exam = _exams.Single(x => x.ExamNumber == examNumber);

        var student = new Student(Guid.NewGuid())
        {
            FamilyName = person.FamilyName,
            FirstName = person.FirstName
        };

        student.AddExam(exam);
        exam.AddStudent(student);

        _students.Add(student);

        return student;
    }

    public void InschribeToExam(Guid studentNumber, Guid examNumber)
    {
        var student = _students.Single(x => x.StudentNumber == studentNumber);
        var exam = _exams.Single(x => x.ExamNumber == examNumber);

        student.AddExam(exam);
        exam.AddStudent(student);
    }

    public void TrySetExamResult(Guid studentNumber, Guid examNumber, bool hasPassed)
    {
        var student = _students.Single(x => x.StudentNumber == studentNumber);
        var exam = student.TryGetExam(examNumber);
        if (exam is null)
        {
            var existingExam = _exams.Single(x => x.ExamNumber == examNumber);
            Console.WriteLine($"Could not find exam {existingExam} for student {student}");
            return;
        }

        var examResult = new ExamResult(exam, student, hasPassed);

        student.ReceiveExamResult(examNumber, hasPassed);
        exam.ReportExamResult(student, hasPassed);
    }
}
