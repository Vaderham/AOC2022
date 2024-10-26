using System.ComponentModel.Design;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayEleven\", "Input.txt");

var lines = File.ReadAllLines(path);
var monkeys = ProcessInput(lines);



IList<Monkey> ProcessInput(string[] strings)
{
    var monkeys = new List<Monkey>();
    for (var i = 0; i < strings.Length; i += 7)
    {
        var monkey = new Monkey();
        for (int j = i; j < i+6; j++)
        {
            if (strings[j].StartsWith("Monkey")) continue;
            if (strings[j].StartsWith("  Starting items:"))
            {
                monkey.Items = strings[j].Split(" ")
                    .Select(s => s.Replace(',', ' ').Trim())
                    .Where(s => int.TryParse(s, out var _))
                    .Select(int.Parse).ToList();
            }

            if (strings[j].StartsWith("  Operation: "))
            {
                var split = strings[j].Split(" ").TakeLast(2).ToArray();
                monkey.Operation = split[0] switch
                {
                    "*" => (x) => x * int.Parse(split[1]),
                    "+" => (x) => x + int.Parse(split[1]),
                    _ => monkey.Operation
                };
            }

            if (strings[j].StartsWith("  Test: "))
            {
                var split = strings[j].Split(" ").TakeLast(1).Select(int.Parse);
                var trueResult = strings[j+1].Split(" ").TakeLast(1).Select(int.Parse);
                var falseResult = strings[j+2].Split(" ").TakeLast(1).Select(int.Parse);
                monkey.GetTargetMonkey = (worryLevel) => worryLevel % split.First() == 0 ? trueResult.First() : falseResult.First();
            }
        }
        monkeys.Add(monkey);
    }

    return monkeys;
}

internal class Monkey
{
    public List<int> Items { get; set; }
    public Func<int, int> Operation { get; set; }
    public Func<int, int> GetTargetMonkey { get; set; }
}