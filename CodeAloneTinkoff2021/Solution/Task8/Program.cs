Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_8.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var str = lines[0];
var charsByDigit = new Dictionary<char, string>
{
    {'2', "ABC" },
    {'3', "DEF" },
    {'4', "GHI" },
    {'5', "JKL" },
    {'6', "MNO" },
    {'7', "PQRS" },
    {'8', "TUV" },
    {'9', "WXYZ" }
};

var digitsInARow = 1;
var result = new List<char>();

for (var i = 0; i < str.Length; i++)
{
    if (i < str.Length - 1 && str[i + 1] == str[i])
    {
        // if there is a same char in the next position
        digitsInARow++;
        continue;
    }

    // this is the last char in the sequence of the same chars

    var remainder = digitsInARow % charsByDigit[str[i]].Length;
    var occurences = digitsInARow / charsByDigit[str[i]].Length;

    if (remainder > 0)
    {
        result.Add(charsByDigit[str[i]][remainder - 1]);
    }

    for (var j = 0; j < occurences; j++)
    {
        result.Add(charsByDigit[str[i]][^1]);
    }

    digitsInARow = 1;
}

Console.WriteLine(result.ToArray());

