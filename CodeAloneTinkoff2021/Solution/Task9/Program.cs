Console.WriteLine("Hello, World!");

var fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Resources\advent_9.test.txt");

if (!File.Exists(fileName))
{
    Console.WriteLine("File not found. Path: " + fileName);
    return;
}

var lines = File.ReadAllLines(fileName);
var nums = lines[1]
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x) - 1)
    .ToArray();

// Числа встречаются в строке ровно по 1 разу, что это значит:
// 1. Что между последовательностямми нет общих подпоследовательностей, а значит мы можем рассматривать их изолированно
// 2. Что все последовательности - циклы

var sequenceLengths = new Dictionary<int, int>();
var sequenceByNextNumber = new Dictionary<int, int>();

for (var i = 0; i < nums.Length; i++)
{
    var currentSequenceStartNumber = i;
    var currentSequenceLength = 0;

    // Если существует последовательность ожидающая текущее число как следующее
    if (sequenceByNextNumber.ContainsKey(i))
    {
        currentSequenceStartNumber = sequenceByNextNumber[i];
        currentSequenceLength = sequenceLengths[currentSequenceStartNumber];
        sequenceByNextNumber.Remove(i);
    }

    // Если следующее подходящее число - это начало другой существующей последовательности
    if (nums[i] != currentSequenceStartNumber && sequenceLengths.ContainsKey(nums[i]))
    {
        // Сливаем эти две последовательности и подчищаем записи в словарях
        sequenceLengths[currentSequenceStartNumber] = currentSequenceLength + sequenceLengths[nums[i]] + 1;
        sequenceLengths.Remove(nums[i]);
        var nextNumberForSubsequence = sequenceByNextNumber.First(x => x.Value == nums[i]).Key;
        sequenceByNextNumber[nextNumberForSubsequence] = currentSequenceStartNumber;
    }
    else
    {
        // Добаляем текущее число в последовательность, которая ожидает его как следующее
        // (или создаем новую, если такой не нашлось)
        sequenceLengths[currentSequenceStartNumber] = currentSequenceLength + 1;
        sequenceByNextNumber[nums[i]] = currentSequenceStartNumber;
    }
}

Console.WriteLine(sequenceLengths.Values.Max());