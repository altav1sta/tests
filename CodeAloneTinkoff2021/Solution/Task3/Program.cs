Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_3.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);

var length = int.Parse(lines[0].Split(' ').Last());

var pieces = lines[1].Split(' ').Select(x => int.Parse(x)).ToArray();
pieces = pieces.OrderByDescending(x => x).ToArray();

var sum = 0;
var knots = -1;

foreach (var piece in pieces)
{
    sum += piece;
    knots++;

    if (sum >= length) break;
}

Console.WriteLine(knots);
