
Console.WriteLine("Hello, World!");

int decimalPlaces = 14;
long number = long.Parse(new String('9', decimalPlaces));
long sqrtOfMaxNumber = (long) Math.Sqrt(number);
long curMax = 0;
long curX = 0;
long curY = 0;
long startI = Math.Min(sqrtOfMaxNumber + 100, number / 2);

for (long i = sqrtOfMaxNumber + 100; i > 2; i--)
{
    if (!IsPrime(i)) continue;

    var startJ = Math.Max(i - 100, 2);
    var maxChanged = false;
    for (long j = startJ; j <= i; j++)
    {
        var m = i * j;
        var length = m.ToString().Length;
        
        if (length > decimalPlaces) break;

        if (length < decimalPlaces) continue;

        if (!IsPrime(j)) continue;

        if (m > curMax)
        {
            curMax = m;
            curX = i;
            curY = j;
            maxChanged = true;
        }
    }

    if (maxChanged)
    {
        Console.WriteLine($"{curX} * {curY} = {curMax}");
        Console.ReadLine();
    }
}


long GreatestDivisor(long num)
{
    for (long i = num / 2; i > 1; i--)
    {
        if (num % i == 0) return i;
    }

    return 1;
}

bool IsPrime(long num)
{
    return GreatestDivisor(num) == 1;
}