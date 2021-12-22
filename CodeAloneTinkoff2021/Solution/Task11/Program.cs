Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_11.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var screamers = lines
    .Select(line => line
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .Skip(1)
        .ToArray())
    .ToArray();

//screamers = new[]
//{
//    new int[] {  },
//    new int[] { 2, 3 },
//    new int[] { },
//    new int[] { 4 },
//    new int[] { },
//};
var rightBounds = Enumerable.Range(0, screamers.Length)
    .ToDictionary(
        x => x,
        x => screamers
            .Select((item, index) => (item.ToList(), index))
            .Where(item => item.Item1.Contains(x))
            .Select(x => x.index)
            .ToList());
var orderedScreamers = new List<int>();


for (int i = 1; i < screamers.Length; i++)
{
    if (orderedScreamers.Contains(i)) continue;
    Insert(i);
}

long sum = 0;

for (int i = 0; i < orderedScreamers.Count; i++)
{
    sum += orderedScreamers[i] * (i + 1);
}

Console.WriteLine(sum);

void Insert(int item)
{
    foreach (var child in screamers[item])
    {
        if (!orderedScreamers.Contains(child)) Insert(child);
    }

    var leftBoundIndex = MaxIndex(screamers[item]);
    var rightBoundIndex = MinIndex(rightBounds[item]);
    InsertByValue(item, leftBoundIndex + 1, rightBoundIndex);
    //Console.WriteLine(String.Join(' ', orderedScreamers));
}

int InsertByValue(int value, int leftBound, int rightBound)
{
    for (int i = leftBound; i < rightBound; i++)
    {
        if (orderedScreamers[i] > value)
        {
            orderedScreamers.Insert(i, value);
            return i;
        }
    }

    orderedScreamers.Insert(rightBound, value);
    return rightBound;
}

int MinIndex(IList<int> values)
{
    var minIndex = orderedScreamers.Count;
    foreach (var value in values)
    {
        var index = orderedScreamers.IndexOf(value);
        if (index > -1) minIndex = Math.Min(minIndex, index);
    }
    return minIndex;
}

int MaxIndex(IList<int> values)
{
    var maxIndex = -1;
    foreach (var value in values)
    {
        var index = orderedScreamers.IndexOf(value);
        if (index > -1) maxIndex = Math.Max(maxIndex, index);
    }
    return maxIndex;
}