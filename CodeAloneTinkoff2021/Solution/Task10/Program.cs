Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_10.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var nums = lines[1]
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

var max = 0;
var levelIndexes = new Dictionary<int, int>();

for (var i = 0; i < nums.Length; i++)
{
    var higherLevels = levelIndexes.Where(x => x.Key > nums[i]).ToList();
    
    if (!levelIndexes.ContainsKey(nums[i]))
    {
        levelIndexes[nums[i]] = higherLevels.Count > 0
            ? higherLevels.Min(x => x.Value)
            : i;
    }

    foreach (var level in higherLevels)
    {
        var square = level.Key * (i - level.Value);
        max = Math.Max(max, square);
        levelIndexes.Remove(level.Key);
    }
}

foreach (var level in levelIndexes)
{
    var square = level.Key * (nums.Length - level.Value);
    max = Math.Max(max, square);
}

Console.WriteLine(max);