using System.Data.Common;

namespace AdventOfCode2025.Days.Day06;

internal class Solution : BaseSolution
{
    protected override object SolvePart1()
    {
        long result = 0;

        var data = _input.Split(Environment.NewLine).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();

        for (int column = 0; column < data[0].Count(); column++)
        {
            long subTotal = long.Parse(data[0][column]);

            char operation = data[^1][column][0];

            for (int row = 1; row < data.Count - 1; row++)
            {
                switch (operation)
                {
                    case '+':
                        subTotal += long.Parse(data[row][column]);
                        break;
                    case '*':
                        subTotal *= long.Parse(data[row][column]);
                        break;
                }
            }

            result += subTotal;
        }

        return result;
    }

    protected override object SolvePart2()
    {
        long result = 0;

        string[] lines = _input.Split(Environment.NewLine);

        long subTotal = 0;
        char operation = ' ';

        for (int col = 0; col < lines[^1].Length; ++col)
        {
            if (lines.All(x => x[col] == ' ')) continue;

            var newOperation = lines[^1][col];

            long number = long.Parse(new string(lines[..^1].Select(x => x[col]).ToArray()).Trim());

            if (newOperation != ' ')
            {
                result += subTotal;

                subTotal = number;
                operation = newOperation;
                continue;
            }

            switch (operation)
            {
                case '+':
                    subTotal += number;
                    break;
                case '*':
                    subTotal *= number;
                    break;
            }
        }

        result += subTotal;

        return result;
    }
}
