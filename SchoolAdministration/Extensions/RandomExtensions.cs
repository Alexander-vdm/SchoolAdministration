namespace SchoolAdministration.Extensions;

internal static class RandomExtensions
{
    public static bool NextBoolean(this Random rng)
    {
        return rng.Next(0, 2) != 0;
    }
}
