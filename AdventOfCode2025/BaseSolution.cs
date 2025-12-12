namespace AdventOfCode2025;

internal abstract class BaseSolution
{
    protected int _day = 1;
    protected readonly string _input;

    public BaseSolution()
    {
        string dayName = GetType().Namespace?.Split('.').Last() ?? throw new InvalidOperationException("Unable to detect day folder from namespace.");

        _day = int.Parse(dayName.Replace("Day", ""));

        string path = Path.Combine("Days", dayName, "Input.txt");
        _input = File.ReadAllText(path);
    }

    public void Run()
    {
        Console.WriteLine("=== Day 01 ===");

        Console.WriteLine("Part 1: " + SolvePart1());
        Console.WriteLine("Part 2: " + SolvePart2());
    }

    protected abstract object SolvePart1();

    protected abstract object SolvePart2();
}
