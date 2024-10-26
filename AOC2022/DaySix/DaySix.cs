using AOC2022.Utils;

namespace AOC2022.DaySix;

public class DaySix : ISolvedDay
{
    public void Solution()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DaySix\", "Input.txt");

        var file = File.ReadAllText(path);

        var charArray = file.ToCharArray();

//Part One
// var currentFour = new Queue<char>();
//
// for (int i = 0; i < charArray.Length; i++)
// {
//     currentFour.Enqueue(charArray[i]);
//     if (currentFour.Count > 4)
//     {
//         currentFour.Dequeue();
//     }
//
//     if (currentFour.Count == 4)
//     {
//         var distinct = currentFour.Distinct();
//         if (distinct.Count() == 4)
//         {
//             Console.WriteLine(i + 1);
//             break;
//         }
//     }
// }

//Part Two
        var currentFour = new Queue<char>();

        for (int i = 0; i < charArray.Length; i++)
        {
            currentFour.Enqueue(charArray[i]);
            if (currentFour.Count > 14)
            {
                currentFour.Dequeue();
            }

            if (currentFour.Count == 14)
            {
                var distinct = currentFour.Distinct();
                if (distinct.Count() == 14)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}