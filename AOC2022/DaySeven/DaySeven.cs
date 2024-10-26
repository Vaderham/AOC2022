using AOC2022.Utils;

namespace AOC2022.DaySeven;

public class DaySeven : ISolvedDay
{
    public void Solution()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DaySeven\", "Input.txt");

var file = File.ReadAllLines(path);

// Part One
// var root = new Dir();
// var currentNode = root;
//
// for (var i = 0; i < file.Length; i++)
// {
//     var line = file[i];
//     if (line.StartsWith('$'))
//     {
//         var parts = line.Split(' ');
//         switch (parts[1])
//         {
//             case "cd":
//                 if (parts[2] == "/")
//                 {
//                     currentNode = root;
//                     break;
//                 }
//
//                 currentNode = parts[2] == ".."
//                     ? currentNode.Parent
//                     : currentNode.Dirs[parts[2]];
//                 break;
//             case "ls":
//                 i = ProcessLS(i + 1);
//                 break;
//         }
//     }
// }
//
// var dirToSizes = GetDirSizes(root).Where(d => d.Value <= 100000).Sum(d => d.Value);
//
// Console.Write(dirToSizes);


var root = new Dir();
var currentNode = root;

for (var i = 0; i < file.Length; i++)
{
    var line = file[i];
    if (line.StartsWith('$'))
    {
        var parts = line.Split(' ');
        switch (parts[1])
        {
            case "cd":
                if (parts[2] == "/")
                {
                    currentNode = root;
                    break;
                }

                currentNode = parts[2] == ".."
                    ? currentNode.Parent
                    : currentNode.Dirs[parts[2]];
                break;
            case "ls":
                i = ProcessLS(i + 1);
                break;
        }
    }
}

var dirToSizes = GetDirSizes(root);
var orderedDescendingBySize = dirToSizes.OrderByDescending(d => d.Value);

var totalSize = 70000000;
var requiredSpace = 30000000;

var amountUsed = totalSize - orderedDescendingBySize.First().Value;
var amountNeeded = requiredSpace - amountUsed;

var smallestPossible = dirToSizes
    .Where(d => d.Value > amountNeeded)
    .OrderBy(d => d.Value)
    .First();

Console.Write(smallestPossible.Value);


Dictionary<Dir, long> GetDirSizes(Dir node)
    {
        var sizes = new Dictionary<Dir, long>();
    
        if (!sizes.TryGetValue(node, out _))
        {
            sizes.Add(node, 0);
        }
    
        sizes[node] = GetDirFileSizes(node);
    
        foreach (var directory in node.Dirs)
        {
            sizes = sizes.Concat(GetDirSizes(directory.Value)).ToDictionary();
        }
    
        return sizes;
    }
    
    long GetDirFileSizes(Dir node)
    {
        var total = (long)node.Files.Sum(f => f.Size);
        foreach (var dir in node.Dirs)
        {
            total += GetDirFileSizes(dir.Value);
        }
    
        return total;
    }
    
    
    int ProcessLS(int currentIndex)
    {
        var currentLine = file[currentIndex];
        var linesToProcess = new List<string>();
        while (!currentLine.StartsWith('$') && file.Length > currentIndex + 1)
        {
            linesToProcess.Add(currentLine);
            currentLine = file[currentIndex + linesToProcess.Count];
        }
    
        // Process the lines
        foreach (var line in linesToProcess)
        {
            var parts = line.Split(" ");
            if (parts[0] == "dir")
            {
                currentNode.Dirs.Add(parts[1], new Dir()
                {
                    Name = parts[1],
                    Parent = currentNode
                });
                continue;
            }
    
            if (int.TryParse(parts[0], out var size))
            {
                currentNode.Files.Add(new Fil()
                {
                    Name = parts[1],
                    Size = size
                });
            }
        }
    
        return currentIndex + linesToProcess.Count - 1;
    }
    }
    
    
    
    internal class Dir
    {
        public string Name { get; set; }
        public IDictionary<string, Dir> Dirs { get; set; } = new Dictionary<string, Dir>();
        public IList<Fil> Files { get; set; } = new List<Fil>();
        public Dir? Parent { get; set; }
    }
    
    internal class Fil
    {
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
    }
}