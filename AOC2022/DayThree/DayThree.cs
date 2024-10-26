using AOC2022.Utils;

namespace AOC2022.DayThree;

public class DayThree : ISolvedDay
{
    public void Solution()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayThree\", "Input.txt");

        var file = File.ReadAllLines(path);

// Part One
// var parsedInput = file.Select(s =>
// {
//     var string1 = s.Substring(0, s.Length / 2);
//     var string2 = s.Substring(s.Length / 2 , string1.Length);
//     return new List<List<char>>()
//     {
//         string1.ToCharArray().ToList(),
//         string2.ToCharArray().ToList()
//     };
// });
//
// var output = parsedInput
//     .SelectMany(lol => lol[0]
//         .Intersect(lol[1]))
//     .Select(c => char.IsUpper(c) ? c - 38 : c - 96)
//     .Sum();

// Part Two
        var charConverted = file.Select(s => s.ToCharArray().ToList()).ToList();

        var parsedInput = new List<List<List<char>>>();

        for (var i = 0; i < charConverted.Count; i += 3)
        {
            parsedInput.Add([
                charConverted[i],
                charConverted[i + 1],
                charConverted[i + 2]
            ]);
        }

        var output = parsedInput
            .SelectMany(g => g[0].Intersect(g[1].Intersect(g[2])))
            .Select(c => char.IsUpper(c) ? c - 38 : c - 96)
            .Sum();

        Console.WriteLine(output);
    }
}