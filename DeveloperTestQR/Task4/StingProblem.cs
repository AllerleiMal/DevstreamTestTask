using System.Text;

namespace Task4;

public static class StingProblem
{
    public static string ReverseString(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return "";
        }
    
        var result = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; --i)
        {
            result.Append(s[i]);
        }

        return result.ToString();
    }
    
    public static bool IsPalindrome(string s)
    {
        if (s is null)
        {
            return false;
        }

        var lowerS = s.ToLowerInvariant();
        
        for (int i = 0; i < lowerS.Length / 2; ++i)
        {
            if (lowerS[i] != lowerS[lowerS.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}