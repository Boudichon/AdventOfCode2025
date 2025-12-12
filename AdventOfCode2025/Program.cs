using System.Reflection;

Console.WriteLine("Which day? (1-25)");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int day) || day < 1 || day > 25)
{
    Console.WriteLine("Invalid day.");
    return;
}

string dayName = $"Day{day:00}";
string typeName = $"AdventOfCode2025.Days.{dayName}.Solution";

Type? solutionType = Assembly.GetExecutingAssembly().GetType(typeName);

if (solutionType == null)
{
    Console.WriteLine($"Solution for {dayName} not found.");
    return;
}

dynamic? solver = Activator.CreateInstance(solutionType);
solver?.Run();
