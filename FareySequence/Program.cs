using System.Diagnostics;
using System.Runtime.CompilerServices;
using FareySequence;

GetFareiSequence(10);

//FillFareiSequence(0);



void GetFareiSequence(int n)
{
    var stopwatch = Stopwatch.StartNew();
    Console.WriteLine("{0} / {1}", 0, 1);
    FareiSequence(n, 0, 1, 1, 1);
    Console.WriteLine("{0} / {1}", 1, 1);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
}

void FareiSequence(int n, int x, int y, int z, int t)
{
    int a = x + z, b = y + t;
    if (b <= n)
    {
        FareiSequence(n, x, y, a, b);
        Console.WriteLine("{0} / {1}", a, b);
        FareiSequence(n, a, b, z, t);
    }
}

//TODO: реализовать через двунаправленный список!
void FillFareiSequence(int n)
{
    var list = new BidirectionaLinearList<Fraction>();
    list.Add(new Fraction
    {
        Numerator = 0,
        Denominator = 1
    });
    list.Add(new Fraction
    {
        Numerator = 1,
        Denominator = 1
    });

    var head = list.Head;
    while (head != null)
    {
        Console.WriteLine($"{head.Data.Numerator} / {head.Data.Denominator}");
        head = head.Next;
    }
}

