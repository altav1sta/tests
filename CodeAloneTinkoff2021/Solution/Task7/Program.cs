Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_7.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var cans = lines.Select(line =>
    line
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .Skip(1)
    .ToArray())
    .ToArray();
//var cans = new[]
//{
//    new int[] {  },
//    new int[] { 2, 3 },
//    new int[] { },
//    new int[] {}
//};
var mostSticky = new HashSet<int>();
Console.WriteLine();
for (var i = 1; i < cans.Length; i++)
{
    if (cans[i].Length == 0) // we don't know what is more sticky than i
    {
        if (!mostSticky.Contains(i)) mostSticky.Add(i);
    }
    else
    {
        if (mostSticky.Contains(i)) mostSticky.Remove(i);

        foreach (var can in cans[i])
        {
            if (!mostSticky.Contains(can) && can > i) mostSticky.Add(can);
        }
    }
}

Console.WriteLine(String.Join(" ", mostSticky.OrderBy(x => x)));
Console.WriteLine();
Console.WriteLine(mostSticky.Sum());
Console.WriteLine(cans.Select((item, index) => item.Length == 0 ? index : 0).Sum());