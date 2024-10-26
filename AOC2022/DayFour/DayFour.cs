using AOC2022.Utils;

namespace AOC2022.DayFour;

public class DayFour : ISolvedDay
{
    public void Solution()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayFour\", "Input.txt");

        var file = File.ReadAllLines(path);

// Part One
// var parsedInput = file
//     .Select(line => line.Split(","))
//     .Select(s => s.Select(i => i.Split("-"))
//         .Select(GetFullNumberLine))
//     .Where(list =>
//     {
//         var enumerable = list.ToList();
//         return enumerable.First().All(i => enumerable.Last().Contains(i)) ||
//                enumerable.Last().All(i => enumerable.First().Contains(i));
//     }).Count();
//
// Console.WriteLine(parsedInput);

// Part Two
        var parsedInput = file
            .Select(line => line.Split(","))
            .Select(s => s.Select(i => i.Split("-"))
                .Select(GetFullNumberLine))
            .Where(list =>
            {
                var enumerable = list.ToList();
                return enumerable.First().Any(i => enumerable.Last().Contains(i));
            }).Count();

        Console.WriteLine(parsedInput);

        List<int> GetFullNumberLine(string[] pair)
        {
            var asInts = pair.Select(int.Parse).ToList();
            var result = new List<int>();
            for (int i = asInts[0]; i <= asInts[1]; i++)
            {
                result.Add(i);
            }

            return result;
        }
    }
}