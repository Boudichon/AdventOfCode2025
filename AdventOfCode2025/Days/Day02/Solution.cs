using System.Collections.Generic;

namespace AdventOfCode2025.Days.Day02;

internal class Solution : BaseSolution
{
    protected override object SolvePart1()
    {
        List<string> ranges = _input.ReplaceLineEndings("").Split(',').ToList();

        double total = 0;

        foreach (string range in ranges)
        {
            string[] parts = range.Split('-');
            double start = double.Parse(parts[0]);
            double end = double.Parse(parts[1]);

            for (double i = start; i <= end; ++i)
            {
                string numStr = i.ToString();

                if (numStr.Length % 2 == 0)
                {
                    string firstHalf = numStr[..(numStr.Length / 2)];
                    string secondHalf = numStr[(numStr.Length / 2)..];

                    if (firstHalf == secondHalf)
                    {
                        total += i;
                    }
                }
            }
        }

        return total;
    }

    protected override object SolvePart2()
    {
        List<string> ranges = _input.ReplaceLineEndings("").Split(',').ToList();

        double total = 0;

        foreach (string range in ranges)
        {
            string[] parts = range.Split('-');
            double start = double.Parse(parts[0]);
            double end = double.Parse(parts[1]);

            for (double i = start; i <= end; ++i)
            {
                string numStr = i.ToString();

                string doubled = numStr + numStr;
                string trimmed = doubled.Substring(1, doubled.Length - 2);

                if (trimmed.Contains(numStr)) total += i;
            }
        }

        return total;
    }
}
