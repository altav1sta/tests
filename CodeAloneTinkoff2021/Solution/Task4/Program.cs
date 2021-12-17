Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_4.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var blades = lines[1].Split(' ').Select(x => int.Parse(x)).ToArray();
//var blades = new int[] { 1, 2, 1, 2 };
var count = blades.Length;

for (var periodLength = 1; periodLength <= blades.Length / 2; periodLength++)
{
    if (blades.Length % periodLength == 0)
    {
        var periodic = PeriodicWithThatLength(blades, periodLength);

        if (periodic)
        {
            count = periodLength;
            break;
        }
    }
}

Console.WriteLine(count);

bool PeriodicWithThatLength(int[] sequence, int periodLength)
{
    for (var cycle = 1; cycle < sequence.Length / periodLength; cycle++)
    {
        for (var i = 0; i < periodLength; i++)
        {
            if (sequence[i] != sequence[i + cycle * periodLength])
                return false;
        }
    }

    return true;
}