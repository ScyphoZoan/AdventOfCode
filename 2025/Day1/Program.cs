using System.Security.Cryptography;

namespace Day1;

class Program
{
    public static int currentPosition = 50;

    public static int zeroCount = 0;

    static void Main(string[] args)
    {
        DataCollection();
        Console.WriteLine(zeroCount);
    }

    static public void DataCollection()
    {
        using var sr = new StreamReader("Inputs.txt");
        while (sr.ReadLine() is { } line)
        {
            if (line[0] == 'L')
            {
                calculateRotation(false, int.Parse(line.AsSpan(1)));
            }
            else
            {
                calculateRotation(true, int.Parse(line.AsSpan(1)));
            }
        }
    }

    public static void calculateRotation(bool direction, int number)
    {
        if (direction)
        {
            for (int i = 0; i < number; i++)
            {
                currentPosition += 1;
                if (currentPosition == 100)
                {
                    currentPosition = 0;
                }

                if (currentPosition == 0)
                {
                    zeroCount++;
                }
            }
        }
        else
        {
            for (int i = 0; i < number; i++)
            {
                currentPosition -= 1;
                if (currentPosition == -1)
                {
                    currentPosition = 99;
                }

                if (currentPosition == 0)
                {
                    zeroCount++;
                }
            }
        }
    }
}