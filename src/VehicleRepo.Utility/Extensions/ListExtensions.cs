namespace VehicleRepo.Utility.Extensions;

public static class ListExtensions
{
    public static bool IsNullOrEmpty<T>(this List<T> input)
    {
        return (input == null) || !input.Any();
    }
}