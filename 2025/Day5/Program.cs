namespace Day5;

class Program
{
    static void Main(string[] args)
    {
        var (fresh, ingredients) = ParseData();

        var part1 = AvailableIngredients(fresh, ingredients);
        Console.WriteLine(part1);

        var part2 = FreshList();
        Console.WriteLine(part2);
    }

    private static int AvailableIngredients(List<FreshRange> fresh, List<long> ingredients)
    {
        var freshCount = 0;
        foreach (var ingredient in ingredients)
        {
            foreach (var freshRange in fresh)
            {
                if (freshRange.Contains(ingredient))
                {
                    freshCount++;
                    break;
                }
            }
        }

        return freshCount;
    }

    static (List<FreshRange> fresh, List<long> ingredients) ParseData()
    {
        List<FreshRange> fresh = [];
        using var sr = new StreamReader("Inputs.txt");
        while (sr.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            var split = line.Split('-');
            var start = long.Parse(split[0]);
            var end = long.Parse(split[1]);

            fresh.Add(new FreshRange(start, end));
        }

        List<long> ingredients = [];
        while (sr.ReadLine() is { } line)
        {
            ingredients.Add(long.Parse(line));
        }

        return (fresh, ingredients);
    }

    static List<FreshRange> ParseDataPartTwo()
    {
        List<FreshRange> fresh = [];
        using var sr = new StreamReader("Inputs.txt");
        while (sr.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            var split = line.Split('-');
            var start = long.Parse(split[0]);
            var end = long.Parse(split[1]);
        }

        return fresh;
    }

    private static long FreshList()
    {
        long freshCount = 0;
        var fresh = ParseDataPartTwo();
        foreach (var freshRange in fresh)
        {
            freshCount += freshRange.End - freshRange.Start + 1;
        }

        return freshCount;
    }

    record struct FreshRange
    {
        public FreshRange(long start, long end)
        {
            Start = start;
            End = end;
        }

        public long Start { get; init; }
        public long End { get; init; }

        public bool Contains(long num)
        {
            return Start <= num && num <= End;
        }
    }
}