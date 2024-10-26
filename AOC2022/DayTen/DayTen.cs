using AOC2022.Utils;

namespace AOC2022.DayTen;

public class DayTen : ISolvedDay
{
    public void Solution()
    {
        // Part One
        
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayTen\", "Input.txt");

        var lines = File.ReadAllLines(path).Select(s => s.Split(" "));

        var cycle = 0;
        var x = 1;
        var cycleCheckBase = 20;
        var cycleCheckIncrement = 40;

        var strengths = new List<int>();

        foreach (var line in lines)
        {
            var command = line[0];

            switch (command)
            {
                case "noop":
                    IncrementCycle();
                    break;
                case "addx":
                    for (int i = 0; i < 2; i++)
                    {
                        IncrementCycle();
                    }
                    x += int.Parse(line[1]);
                    break;
            }
        }

        Console.WriteLine("Total: " + strengths.Sum());

        void IncrementCycle()
        {
            cycle++;
            if (cycle == cycleCheckBase)
            {
                var signalStrength = cycle * x;
                Console.WriteLine($"cycle {cycle}. Current signal strength: {signalStrength}");
                strengths.Add(signalStrength);
                cycleCheckBase += cycleCheckIncrement;
            }
        }
        
        
        // Part Two
        /*
         * var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayTen\", "Input.txt");

var lines = File.ReadAllLines(path).Select(s => s.Split(" "));

var cycle = 0;
var x = 1;
var cycleCheckBase = 20;
var cycleCheckIncrement = 40;

var xOffSet = 0;

var strengths = new List<int>();

var crt = Enumerable.Range(0, 240).Select(r => ',').ToArray();  

foreach (var line in lines)
{
    var command = line[0];
    switch (command)
    {
        case "noop":
            IncrementCycle();
            break;
        case "addx":
            for (int i = 0; i < 2; i++)
            {
                IncrementCycle();
            }
            x += int.Parse(line[1]);
            break;
    }
}

Console.WriteLine("Total: " + strengths.Sum());

for (int i = 0; i < crt.Length; i += 40)
{
    var numbers = Enumerable.Range(i, 40).Select(r => crt[r]);
    Console.WriteLine(string.Join("", numbers));
}

void IncrementCycle()
{
    WriteToCrt();
    cycle++;
    if (cycle == cycleCheckBase)
    {
        var signalStrength = cycle * x;
        Console.WriteLine($"cycle {cycle}. Current signal strength: {signalStrength}");
        strengths.Add(signalStrength);
        cycleCheckBase += cycleCheckIncrement;
    }
}

void WriteToCrt()
{
    List<int> indicesToWrite = [x - 1 + xOffSet, x + xOffSet, x + 1 + xOffSet];

    if (cycle is 39 or 79 or 119 or 159 or 199 or 239)
    {
        xOffSet += 40;
    }
    
    if (indicesToWrite.Contains(cycle)) crt[cycle] = '#';
}

         */
    }
}