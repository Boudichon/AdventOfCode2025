using System.Collections.Generic;

namespace AdventOfCode2025.Days.Day01;

internal class Solution : BaseSolution
{
    protected override object SolvePart1()
    {
        int totalCount = 0;
        int value = 50;

        foreach (string line in _input.Split(Environment.NewLine))
        {
            int rotation = int.Parse(line[1..]);

            if (line.StartsWith('L'))
            {
                rotation *= -1;
            }

            value += rotation;

            if (Mod(value, 100) == 0)
            {
                totalCount++;
            }
        }

        return totalCount;
    }

    protected override object SolvePart2()
    {
        int totalCount = 0;
        int value = 50;

        foreach (string line in _input.Split(Environment.NewLine))
        {
            int rotation = int.Parse(line[1..]);
            int jump = line.StartsWith('L') ? -1 : 1;

            for (int i = 0; i < rotation; ++i)
            {
                value += jump;
                if (Mod(value, 100) == 0)
                {
                    totalCount++;
                }
                if (value < 0)
                {
                    value += 100;
                }
                if (value > 99)
                {
                    value -= 100;
                }
            }
        }

        return totalCount;
    }

    private static int Mod(int a, int n) => ((a % n) + n) % n;
}
