using SchoolAdministration.Enums;

namespace SchoolAdministration.Extensions;

internal static class RandomExtensions
{
    public static ExamResultEnum NextExamResultEnum (this Random rng)
    {
        var values = Enum.GetValues<ExamResultEnum>();
        var index = rng.Next(0, values.Length);
        var value = values[index];

        return value;
    }
}
