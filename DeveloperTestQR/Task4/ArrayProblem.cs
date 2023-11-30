namespace Task4;

public static class ArrayProblem
{
    public static IEnumerable<int> MissingElements(int[] arr)
    {
        if (arr is null || arr.Length < 2)
        {
            return Array.Empty<int>();
        }

        var missingElements = new List<int>();

        for (int i = 0; i < arr.Length - 1; ++i)
        {
            for (int missingElement = arr[i] + 1; missingElement < arr[i + 1]; ++missingElement)
            {
                missingElements.Add(missingElement);
            }
        }

        return missingElements;
    }
}