using AOC2022.Utils;

namespace AOC2022.DayFive;

public class DayFive : ISolvedDay
{
    public void Solution()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayFive\", "Input.txt");

        var file = File.ReadAllLines(path);

// Part One
// var processedStacks = ParseStacks(file.Take(9).ToArray());
//
// var movements = GetMovements(file.Skip(10));
//
// foreach (var movement in movements)
// {
//     var queued = EnqueueRange(processedStacks[movement[1] - 1], movement[0]);
//     foreach (var queuedItem in queued)
//     {
//         processedStacks[movement[2] - 1].Push(queuedItem);
//     }
// }
//
// var topOfStacks = processedStacks.SelectMany(s => s.Take(1));
//
// foreach (var item in topOfStacks)
// {
//     Console.Write(item);
// }


// Part Two
        var processedStacks = ParseStacks(file.Take(9).ToArray());

        var movements = GetMovements(file.Skip(10));

        foreach (var movement in movements)
        {
            var queued = PopRange(processedStacks[movement[1] - 1], movement[0]);
            foreach (var queuedItem in queued)
            {
                processedStacks[movement[2] - 1].Push(queuedItem);
            }
        }

        var topOfStacks = processedStacks.SelectMany(s => s.Take(1));

        foreach (var item in topOfStacks)
        {
            Console.Write(item);
        }

        return;

        List<List<int>> GetMovements(IEnumerable<string> movements)
        {
            var workedMovements = movements
                .Select(movement => movement
                    .Split(" ")
                    .Where(s => int.TryParse(s, out _)));

            return workedMovements.Select(l => l.Select(s => int.Parse(s.ToString())).ToList()).ToList();
        }
    }

    Queue<char> EnqueueRange(Stack<char> stack, int count)
    {
        var queue = new Queue<char>();
        for (var i = 0; i < count; i++)
        {
            queue.Enqueue(stack.Pop());
        }

        return queue;
    }

    Stack<char> PopRange(Stack<char> stack, int count)
    {
        var newStack = new Stack<char>();
        for (var i = 0; i < count; i++)
        {
            newStack.Push(stack.Pop());
        }

        return newStack;
    }

    List<Stack<char>> ParseStacks(string[] stackInput)
    {
        var stacks = Enumerable.Range(0, 9).Select(list => new Stack<char>()).ToList();
        var asCharArrays = stackInput.Select(s => s.ToCharArray()).ToList();

        for (int i = 8; i >= 0; i--)
        {
            var currentArray = asCharArrays[i];
            for (int j = 0; j < currentArray.Length; j++)
            {
                if (char.IsLetter(currentArray[j]))
                {
                    var stackIndex = (int)Math.Round((decimal)j / 4);
                    stacks.ElementAt(stackIndex).Push(currentArray[j]);
                }
            }
        }

        return stacks;
    }
}