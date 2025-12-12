using System.Collections.Generic;

namespace AdventOfCode2025.Days.Day03;

internal class Solution : BaseSolution
{
    protected override object SolvePart1()
    {
        int result = 0;

        foreach (string line in _input.Split(Environment.NewLine))
        {
            List<int> digits = line.Select(x => int.Parse(x.ToString())).ToList();

            int maxDigit = default;
            int maxIndex = default;

            for (int i = 0; i < digits.Count - 1; ++i)
            {
                if (digits[i] > maxDigit)
                {
                    maxDigit = digits[i];
                    maxIndex = i;
                }
            }

            int secondNumber = digits[(maxIndex + 1)..].Max();

            result += int.Parse($"{maxDigit}{secondNumber}");
        }

        return result;
    }

    protected override object SolvePart2()
    {
        const int numberOfDigits = 12;
        double result = 0;

        foreach (string line in _input.Split(Environment.NewLine))
        {
            List<int> digits = line.Select(x => int.Parse(x.ToString())).ToList();

            List<int> selectedDigits = [];
            int lastIndex = 0;

            for (int i = numberOfDigits; i > 0; --i)
            {
                var availableDigits = digits[lastIndex..^(i - 1)];

                var digit = availableDigits.Max();
                lastIndex += availableDigits.IndexOf(digit) + 1;

                selectedDigits.Add(digit);
            }

            result += double.Parse(string.Join("", selectedDigits));
        }

        return result;
    }
}
