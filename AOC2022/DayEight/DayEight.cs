using AOC2022.Utils;

namespace AOC2022.DayEight;

public class DayEight : ISolvedDay
{
    public void Solution()
    {
var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayEight\", "Input.txt");

var file = File.ReadAllLines(path);

var grid = file.Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

var seenTrees = 0;

for (int i = 0; i < grid.Length; i++)
{
    for (int j = 0; j < grid[i].Length; j++)
    {
        var cell = grid[i][j];
        var rightArray = GetRightArray(i, j + 1);
        var leftArray = GetLeftArray(i, j - 1);
        var aboveArray = GetAboveArray(i - 1, j);
        var belowArray = GetBelowArray(i + 1, j);

        if (CanBeSeen(cell, rightArray, leftArray, aboveArray, belowArray))
        {
            seenTrees++;
        }
    }
}

Console.WriteLine(seenTrees);

// A tree can be seen if
// One of it's arrays are empty (i.e. it's on an edge)
// OR If all of the numbers in one of it's arrays are less than it. 
bool CanBeSeen(int cellValue, List<int> right, List<int> left, List<int> above, List<int> below)
{
    return right.Count == 0 
           || left.Count == 0 
           || above.Count == 0 
           || below.Count == 0
           || right.All(x => x < cellValue) 
           || left.All(x => x < cellValue) 
           || above.All(x => x < cellValue)
           || below.All(x => x < cellValue);
}


List<int> GetRightArray(int y, int x)
{
    var list = new List<int>();
    for (int i = x; i < grid[0].Length; i++)
    {
        list.Add(grid[y][i]);
    }

    return list;
}

List<int> GetLeftArray(int y, int x)
{
    var list = new List<int>();
    for (int i = x; i >= 0; i--)
    {
        list.Add(grid[y][i]);
    }

    return list;
}

List<int> GetAboveArray(int y, int x)
{
    var list = new List<int>();
    for (int i = y; i >= 0; i--)
    {
        list.Add(grid[i][x]);
    }

    return list;
}

List<int> GetBelowArray(int y, int x)
{
    var list = new List<int>();
    for (int i = y; i < grid[0].Length; i++)
    {
        list.Add(grid[i][x]);
    }

    return list;
}
    }
    
    
    // Part Two
    
    // var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayEight\", "Input.txt");
//
// var file = File.ReadAllLines(path);
//
// var grid = file.Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
//
// var scores = new List<int>();
//
// for (int i = 0; i < grid.Length; i++)
// {
//     for (int j = 0; j < grid[i].Length; j++)
//     {
//         var cell = grid[i][j];
//         var rightArray = GetRightArray(i, j + 1);
//         var leftArray = GetLeftArray(i, j - 1);
//         var aboveArray = GetAboveArray(i - 1, j);
//         var belowArray = GetBelowArray(i + 1, j);
//
//         scores.Add(CalculateScenicScore(cell, rightArray, leftArray, aboveArray, belowArray));
//     }
// }
//
// Console.WriteLine(scores.Max());
//
// int CalculateScenicScore(int treeHeight, List<int> right, List<int> left, List<int> above, List<int> below)
// {
//     return GetScore(treeHeight, right)
//     * GetScore(treeHeight, left) * GetScore(treeHeight, above) *
//     GetScore(treeHeight, below);
// }
//
// int GetScore(int treeHeight, List<int> trees)
// {
//     var score = 0;
//     foreach (var tree in trees)
//     {
//         if (tree < treeHeight)
//         {
//             score++;
//         }
//         else if (tree >= treeHeight)
//         {
//             score++;
//             break;
//         }
//     }
//
//     return score;
// }
//
// bool CanBeSeen(int cellValue, List<int> right, List<int> left, List<int> above, List<int> below)
// {
//     return right.Count == 0
//            || left.Count == 0
//            || above.Count == 0
//            || below.Count == 0
//            || right.All(x => x < cellValue)
//            || left.All(x => x < cellValue)
//            || above.All(x => x < cellValue)
//            || below.All(x => x < cellValue);
// }
//
//
// List<int> GetRightArray(int y, int x)
// {
//     var list = new List<int>();
//     for (int i = x; i < grid[0].Length; i++)
//     {
//         list.Add(grid[y][i]);
//     }
//
//     return list;
// }
//
// List<int> GetLeftArray(int y, int x)
// {
//     var list = new List<int>();
//     for (int i = x; i >= 0; i--)
//     {
//         list.Add(grid[y][i]);
//     }
//
//     return list;
// }
//
// List<int> GetAboveArray(int y, int x)
// {
//     var list = new List<int>();
//     for (int i = y; i >= 0; i--)
//     {
//         list.Add(grid[i][x]);
//     }
//
//     return list;
// }
//
// List<int> GetBelowArray(int y, int x)
// {
//     var list = new List<int>();
//     for (int i = y; i < grid[0].Length; i++)
//     {
//         list.Add(grid[i][x]);
//     }
//
//     return list;
// }
    
    
}