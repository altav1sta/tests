Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_5.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var line1Array = lines[0].Split(' ').ToArray();
var codeLength = int.Parse(line1Array[0]);
var orderNumber = int.Parse(line1Array[1]);

var digitVariants = lines
    .Skip(1)
    .Select(line => line.Split(' ').Select(x => int.Parse(x)).ToArray())
    .ToArray();
//var digitVariants = new[]
//{
//    new[] { 1 },
//    new[] { 2 },
//    new[] { 3, 6, 9 },
//    new[] { 4 },
//    new[] { 5, 6 },
//};

var code = digitVariants.Select(x => x[0]).ToArray();
var multiple = 1;

for (var digit = codeLength - 1; digit >= 0; digit--)
{
    var newMultiple = multiple * digitVariants[digit].Length;

    if (newMultiple >= orderNumber)
    {
        while (digit < codeLength)
        {
            var index = orderNumber / multiple - 1;
            index += (orderNumber % multiple == 0 ? 0 : 1);
            code[digit] = digitVariants[digit][index];
            digit++;
            
            if (digit >= codeLength) break;
            
            orderNumber -= index * multiple;
            multiple /= digitVariants[digit].Length;
        }

        break;
    }

    multiple = newMultiple;
}

Console.WriteLine(string.Join(string.Empty, code));