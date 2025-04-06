using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class ExamResult
{
    public ClassRoom ClassRoom { get; set; }

    public Student Student { get; set; }

    public ExamResultEnum Result { get; set; }
}
