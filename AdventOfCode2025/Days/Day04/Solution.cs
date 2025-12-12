namespace AdventOfCode2025.Days.Day04;

internal class Solution : BaseSolution
{
    protected override object SolvePart1()
    {
        char[][] grid = _input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

        int result = 0;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                int totalNeighbors = 0;

                if (grid[row][col] != '@')
                {
                    continue;
                }

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }

                        int neighborRow = row + i;
                        int neighborCol = col + j;

                        if (neighborCol < 0 || neighborCol >= grid[row].Length || neighborRow < 0 || neighborRow >= grid.Length)
                        {
                            continue; // Out of bounds
                        }

                        if (grid[neighborRow][neighborCol] == '@' || grid[neighborRow][neighborCol] == 'X')
                        {
                            totalNeighbors++;
                        }
                    }
                }

                if (totalNeighbors < 4)
                {
                    grid[row][col] = 'X'; // Mark as visited

                    result++;
                }
            }
        }

        return result;
    }

    private void OutputGrid(char[][] grid)
    {
        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                Console.Write(grid[row][col]);
            }
            Console.WriteLine();
        }
    }

    protected override object SolvePart2()
    {
        char[][] grid = _input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

        int result = 0;
        int previousResult = 0;

        do
        {
            previousResult = result;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    int totalNeighbors = 0;

                    if (grid[row][col] != '@')
                    {
                        continue;
                    }

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }

                            int neighborRow = row + i;
                            int neighborCol = col + j;

                            if (neighborCol < 0 || neighborCol >= grid[row].Length || neighborRow < 0 || neighborRow >= grid.Length)
                            {
                                continue; // Out of bounds
                            }

                            if (grid[neighborRow][neighborCol] == '@' || grid[neighborRow][neighborCol] == 'X')
                            {
                                totalNeighbors++;
                            }
                        }
                    }

                    if (totalNeighbors < 4)
                    {
                        grid[row][col] = '.'; // Mark as visited

                        result++;
                    }
                }
            }
        } while (previousResult != result);

        return result;
    }
}
