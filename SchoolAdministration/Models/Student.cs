namespace SchoolAdministration.Models;

internal class Student : Person
{
    private readonly List<Exam> _exams = [];
    private readonly List<ExamResult> _examResults = [];

    public Student(Guid studentNumber)
    {
        StudentNumber = studentNumber;
    }

    public Guid StudentNumber { get; set; }

    public IReadOnlyList<Exam> Exams => _exams.AsReadOnly();

    public IReadOnlyList<ExamResult> ExamResults => _examResults.AsReadOnly();

    public void AddExam(Exam exam)
    {
        if (!_exams.Any(x => x.ExamNumber == exam.ExamNumber))
        {
            _exams.Add(exam);
        }
    }

    public void ReceiveExamResult(Guid examNumber, bool hasPassed)
    {
        var exam = _exams.Single(x => x.ExamNumber == examNumber);
        var examResult = new ExamResult(exam, this, hasPassed);
        _examResults.Add(examResult);
    }

    public Exam? TryGetExam(Guid examNumber)
    {
        return _exams.SingleOrDefault(x => x.ExamNumber == examNumber);
    }
}
