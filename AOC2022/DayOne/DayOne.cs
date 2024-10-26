namespace AOC2022.DayOne;

// public class DayOne
// { 
//     
//     var elvesLists = new List<List<int>>();
//     var currentList = new List<int>();
//
//         foreach (var line in file)
//     {
//         if (line != string.Empty)
//         {
//             currentList.Add(int.Parse(line));
//             continue;
//         }
//
//         elvesLists.Add(currentList);
//         currentList = [];
//     }
//
//     var totalLists = elvesLists
//         .Select(l => l.Aggregate(0, (input, next) => input + next))
//         .OrderDescending()
//         .Take(3)
//         .Sum();
//
//     Console.WriteLine(totalLists);
//     
// }