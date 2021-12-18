Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_6.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var subsequence = new List<char>();
var x = 0;
var y = 0;

foreach (var c in lines[0])
{
    if (c == 'L')
    {
        if (x > 0) subsequence.Remove('R');
        else subsequence.Add(c);
        x--;
    }
    if (c == 'R')
    {
        if (x < 0) subsequence.Remove('L');
        else subsequence.Add(c);
        x++;
    }
    if (c == 'D')
    {
        if (y > 0) subsequence.Remove('U');
        else subsequence.Add(c);
        y--;
    }
    if (c == 'U')
    {
        if (y < 0) subsequence.Remove('D');
        else subsequence.Add(c);
        y++;
    }
}

Console.WriteLine(subsequence.OrderBy(x => x).ToArray());