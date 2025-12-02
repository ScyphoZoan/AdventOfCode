using System.Security.Cryptography;

namespace Day2;

class Program
{
    static void Main(string[] args)
    {
        var data = ParseData();
        Console.WriteLine($"part 1: {sumInvalidIds(data)}");
        Console.WriteLine($"part 2: {partTwoSum(data)}");
    }

    public struct range
    {
        public long first { get; set; }
        public long last { get; set; }
    }


    static List<range> ParseData()
    {
        var ranges = new List<range>();

        var input = File.ReadAllText("Inputs.txt")
            .Split(',');

        foreach (var id in input)
        {
            var parts = id.Split('-');
            ranges.Add(new range
                {
                    first = long.Parse(parts[0]),
                    last = long.Parse(parts[1])
                }
            );
        }

        return ranges;
    }

    static bool isInvalidId(long id)
    {
        string stringId = id.ToString();
        if (stringId.Length % 2 != 0)
        {
            return true;
        }

        string firstHalf = stringId.Substring(0, stringId.Length / 2);
        string secondHalf = stringId.Substring(stringId.Length - stringId.Length / 2, stringId.Length / 2);
        if (firstHalf == secondHalf)
        {
            return false;
        }

        return true;
    }


    static bool hasRepeatingSequence(string str, int divisions)
    {
        if (str.Length % divisions != 0)
        {
            return false;
        }

        var divisionLen = str.Length / divisions;

        var pattern = str.Substring(0, divisionLen);
        for (var i = 1; i < divisions; i++)
        {
            var substr = str.Substring(divisionLen * i, pattern.Length);

            if (substr != pattern)
            {
                return false;
            }
        }

        return true;
    }

    static long partTwoSum(List<range> ranges)
    {
        var sum = 0L;
        foreach (var range in ranges)
        {
            for (var i = range.first; i <= range.last; i++)
            {
                var str = i.ToString();
                for (var j = 2; j <= str.Length; j++)
                {
                    if (hasRepeatingSequence(str, j))
                    {
                        sum += i;
                        break;
                    }
                }
            }
        }

        return sum;
    }

    static long sumInvalidIds(List<range> ranges)
    {
        var sum = 0L;
        foreach (var range in ranges)
        {
            for (var i = range.first; i <= range.last; i++)
            {
                if (!isInvalidId(i))
                {
                    sum += i;
                }
            }
        }

        return sum;
    }
}