using AOC2022.Utils;

namespace AOC2022.DayNine;

public class DayNine : ISolvedDay
{
    public void Solution()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayNine\", "Input.txt");

        var moves = File.ReadAllLines(path).Select(l => l.Split(" "));

        var headPosition = new Coord(0, 0);
        var tailPosition = new Coord(0, 0);
        var allVisitedCoords = new List<Coord>();

        foreach (var move in moves)
        {
            var distance = int.Parse(move[1]);
            switch (move[0])
            {
                case "L":
                    Console.WriteLine($"Move L {distance}");
                    for (int i = 0; i < distance; i++)
                    {
                        Console.WriteLine($"Move L {i + 1}");
                        headPosition.X--;
                        MoveTail(headPosition, tailPosition);
                        allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
                    }

                    break;
                case "R":
                    Console.WriteLine($"Move R {distance}");
                    for (int i = 0; i < distance; i++)
                    {
                        Console.WriteLine($"Move R {i + 1}");
                        headPosition.X++;
                        MoveTail(headPosition, tailPosition);
                        allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
                    }

                    break;
                case "U":
                    Console.WriteLine($"Move U {distance}");
                    for (int i = 0; i < distance; i++)
                    {
                        Console.WriteLine($"Move U {i + 1}");
                        headPosition.Y++;
                        MoveTail(headPosition, tailPosition);
                        allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
                    }

                    break;
                case "D":
                    Console.WriteLine($"Move D {distance}");
                    for (int i = 0; i < distance; i++)
                    {
                        Console.WriteLine($"Move D {i + 1}");
                        headPosition.Y--;
                        MoveTail(headPosition, tailPosition);
                        allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
                    }

                    break;
            }
        }

        var distinctLocations = allVisitedCoords.DistinctBy(c => new { c.X, c.Y }).ToList();
        Console.WriteLine($"All Visited Coords: {string.Join(", ", distinctLocations.Count)}");

        void MoveTail(Coord currentHeadPosition, Coord currentTailPosition)
        {
            var xDiff = currentHeadPosition.X - currentTailPosition.X;
            var yDiff = currentHeadPosition.Y - currentTailPosition.Y;

            if (Math.Abs(xDiff) > 1)
            {
                if (currentHeadPosition.Y == currentTailPosition.Y)
                {
                    if (currentHeadPosition.X > currentTailPosition.X)
                    {
                        currentTailPosition.X = currentHeadPosition.X - 1;
                    }

                    if (currentHeadPosition.X < currentTailPosition.X)
                    {
                        currentTailPosition.X = currentHeadPosition.X + 1;
                    }
                }
                else
                {
                    if (currentHeadPosition.X > currentTailPosition.X)
                    {
                        currentTailPosition.Y = currentHeadPosition.Y;
                        currentTailPosition.X = currentHeadPosition.X - 1;
                    }

                    if (currentHeadPosition.X < currentTailPosition.X)
                    {
                        currentTailPosition.Y = currentHeadPosition.Y;
                        currentTailPosition.X = currentHeadPosition.X + 1;
                    }
                }
            }

            if (Math.Abs(yDiff) > 1)
            {
                if (currentHeadPosition.X == currentTailPosition.X)
                {
                    if (currentHeadPosition.Y > currentTailPosition.Y)
                    {
                        currentTailPosition.Y = currentHeadPosition.Y - 1;
                    }

                    if (currentHeadPosition.Y < currentTailPosition.Y)
                    {
                        currentTailPosition.Y = currentHeadPosition.Y + 1;
                    }
                }
                else
                {
                    if (currentHeadPosition.Y > currentTailPosition.Y)
                    {
                        currentTailPosition.X = currentHeadPosition.X;
                        currentTailPosition.Y = currentHeadPosition.Y - 1;
                    }

                    if (currentHeadPosition.Y < currentTailPosition.Y)
                    {
                        currentTailPosition.X = currentHeadPosition.X;
                        currentTailPosition.Y = currentHeadPosition.Y + 1;
                    }
                }
            }

            Console.WriteLine($"Head X: {headPosition.X} Tail X: {tailPosition.X} ");
            Console.WriteLine($"Head Y: {headPosition.Y} Tail Y: {tailPosition.Y}");
            Console.WriteLine("");
        }
    }

    private void PartTwo()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DayNine\", "Input.txt");

var moves = File.ReadAllLines(path).Select(l => l.Split(" "));


var allVisitedCoords = new List<Coord>();

// Part One
// foreach (var move in moves)
// {
//     var distance = int.Parse(move[1]);
//     switch (move[0])
//     {
//         case "L":
//             Console.WriteLine($"Move L {distance}");
//             for (int i = 0; i < distance; i++)
//             {
//                 Console.WriteLine($"Move L {i + 1}");
//                 headPosition.X--;
//                 MoveTail(headPosition, tailPosition);
//                 allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
//             }
//
//             break;
//         case "R":
//             Console.WriteLine($"Move R {distance}");
//             for (int i = 0; i < distance; i++)
//             {
//                 Console.WriteLine($"Move R {i + 1}");
//                 headPosition.X++;
//                 MoveTail(headPosition, tailPosition);
//                 allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
//             }
//
//             break;
//         case "U":
//             Console.WriteLine($"Move U {distance}");
//             for (int i = 0; i < distance; i++)
//             {
//                 Console.WriteLine($"Move U {i + 1}");
//                 headPosition.Y++;
//                 MoveTail(headPosition, tailPosition);
//                 allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
//             }
//
//             break;
//         case "D":
//             Console.WriteLine($"Move D {distance}");
//             for (int i = 0; i < distance; i++)
//             {
//                 Console.WriteLine($"Move D {i + 1}");
//                 headPosition.Y--;
//                 MoveTail(headPosition, tailPosition);
//                 allVisitedCoords.Add(new Coord(tailPosition.X, tailPosition.Y));
//             }
//
//             break;
//     }
// }
//
// var distinctLocations = allVisitedCoords.DistinctBy(c => new {c.X, c.Y}).ToList();
// Console.WriteLine($"All Visited Coords: {string.Join(", ", distinctLocations.Count)}");


// Part Two
Coord[] knots = new Coord[10];
knots = knots.Select(k => new Coord(0, 0)).ToArray();

foreach (var move in moves)
{
    var distance = int.Parse(move[1]);
    switch (move[0])
    {
        case "L":
            for (int i = 0; i < distance; i++)
            {
                knots[0].X--;
                for (int j = 1; j < knots.Length; j++)
                {
                    MoveTail(knots[j - 1], knots[j]);
                }
                allVisitedCoords.Add(new Coord(knots.Last().X, knots.Last().Y));
            }
            break;
        case "R":
            for (int i = 0; i < distance; i++)
            {
                knots[0].X++;
                for (int j = 1; j < knots.Length; j++)
                {
                    MoveTail(knots[j - 1], knots[j]);
                }
                allVisitedCoords.Add(new Coord(knots.Last().X, knots.Last().Y));
            }
            break;
        case "U":
            for (int i = 0; i < distance; i++)
            {
                knots[0].Y++;
                for (int j = 1; j < knots.Length; j++)
                {
                    MoveTail(knots[j - 1], knots[j]);
                }
                allVisitedCoords.Add(new Coord(knots.Last().X, knots.Last().Y));
            }
            break;
        case "D":
            for (int i = 0; i < distance; i++)
            {
                knots[0].Y--;
                for (int j = 1; j < knots.Length; j++)
                {
                    MoveTail(knots[j - 1], knots[j]);
                }
                allVisitedCoords.Add(new Coord(knots.Last().X, knots.Last().Y));
            }
            break;
    }

    Print(knots);

    void Print(Coord[] coords)
    {
        // var xSize = coords.Max(c => c.X) - coords.Min(c => c.X);
        // var ySize = coords.Max(c => c.Y) - coords.Min(c => c.Y);
        //
        // var grid = new int[ySize + 1, xSize + 1];
        //
        // for (var index = 0; index < coords.Length; index++)
        // {
        //     var coord = coords[index];
        //     grid[coord.X, coord.Y] = index;
        // }
        //
        // for (int j = 0; j < grid.Length; j++)
        // {
        //     Enumerable.Range(0, xSize).Select(i => grid[j, i]).ToList().ForEach(Console.WriteLine);
        // }
    }
}

var distinctLocations = allVisitedCoords.DistinctBy(c => new { c.X, c.Y }).ToList();
Console.WriteLine($"All Visited Coords: {string.Join(", ", distinctLocations.Count)}");

return;

void MoveTail(Coord currentHeadPosition, Coord currentTailPosition)
{
    var xDiff = currentHeadPosition.X - currentTailPosition.X;
    var yDiff = currentHeadPosition.Y - currentTailPosition.Y;

    // If the next knot is > 1 away on the X axis
    if (Math.Abs(xDiff) > 1)
    {
        // Do this if it's a horizontal movement
        if (currentHeadPosition.Y == currentTailPosition.Y)
        {
            if (currentHeadPosition.X > currentTailPosition.X)
            {
                currentTailPosition.X = currentHeadPosition.X - 1;
            }

            if (currentHeadPosition.X < currentTailPosition.X)
            {
                currentTailPosition.X = currentHeadPosition.X + 1;
            }
        }
        else
        {
            // Do this if it's not horizontal...
            if (currentHeadPosition.X > currentTailPosition.X)
            {
                currentTailPosition.Y = currentHeadPosition.Y;
                currentTailPosition.X = currentHeadPosition.X - 1;
            }

            if (currentHeadPosition.X < currentTailPosition.X)
            {
                currentTailPosition.Y = currentHeadPosition.Y;
                currentTailPosition.X = currentHeadPosition.X + 1;
            }
        }
    }

    if (Math.Abs(yDiff) > 1)
    {
        if (currentHeadPosition.X == currentTailPosition.X)
        {
            // Vertical movement
            if (currentHeadPosition.Y > currentTailPosition.Y)
            {
                currentTailPosition.Y = currentHeadPosition.Y - 1;
            }

            if (currentHeadPosition.Y < currentTailPosition.Y)
            {
                currentTailPosition.Y = currentHeadPosition.Y + 1;
            }
        }
        else
        {
            if (currentHeadPosition.Y > currentTailPosition.Y)
            {
                currentTailPosition.X = currentHeadPosition.X;
                currentTailPosition.Y = currentHeadPosition.Y - 1;
            }

            if (currentHeadPosition.Y < currentTailPosition.Y)
            {
                currentTailPosition.X = currentHeadPosition.X;
                currentTailPosition.Y = currentHeadPosition.Y + 1;
            }
        }
    }
}
    }
    
}

class Coord
{
    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}