namespace AdventOfCode2025.Days.Day05;

internal class Solution : BaseSolution
{
    protected override object SolvePart1()
    {
        int result = 0;

        var sections = _input.Split(Environment.NewLine + Environment.NewLine);

        List<long> numbers = sections[1].Split(Environment.NewLine).Select(long.Parse).ToList();

        foreach (string range in sections[0].Split(Environment.NewLine))
        {
            long min = long.Parse(range.Split('-')[0]);
            long max = long.Parse(range.Split('-')[1]);

            var fresh = numbers.Where(n => n >= min && n <= max).ToList();
            numbers = numbers.Except(fresh).ToList();

            result += fresh.Count;
        }

        return result;
    }

    protected override object SolvePart2()
    {
        long result = 0;

        var sections = _input.Split(Environment.NewLine + Environment.NewLine);

        List<long> numbers = sections[1].Split(Environment.NewLine).Select(long.Parse).ToList();

        List<Range> ranges = [];

        foreach (string range in sections[0].Split(Environment.NewLine))
        {
            long min = long.Parse(range.Split('-')[0]);
            long max = long.Parse(range.Split('-')[1]);

            ranges.Add(new(min, max));
        }

        int previousCount;

        do
        {
            previousCount = ranges.Count;

            // Shrink
            foreach (var range in ranges.ToList())
            {
                Console.WriteLine($"Checking range {range.Min}-{range.Max} for shrink.");

                var overlap = ranges.FirstOrDefault(x => !(x.Min == range.Min && x.Max == range.Max) && x.Min <= range.Min && x.Max + 1 >= range.Min);

                Console.WriteLine(overlap is null
                    ? $"No overlap found for {range.Min}-{range.Max}."
                    : $"Found overlap {overlap.Min}-{overlap.Max} for {range.Min}-{range.Max}.");

                if (overlap is null) continue;

                overlap.Min = Math.Min(overlap.Min, range.Min);
                overlap.Max = Math.Max(overlap.Max, range.Max);
                ranges.Remove(range);

                Console.WriteLine($"Shrunk {range.Min}-{range.Max} into {overlap.Min}-{overlap.Max}.");
            }

        } while (ranges.Count == previousCount);

        result = ranges.Distinct().Sum(x => x.Max - x.Min + 1);

        Console.WriteLine($"Reduced to ranges: {string.Join(", ", ranges.Distinct().Select(x => $"{x.Min}-{x.Max}"))}.");

        return result;
    }

    protected record Range
    {
        public long Min { get; set; }
        public long Max { get; set; }

        public Range(long min, long max)
        {
            Min = min;
            Max = max;
        }
    }
}
