namespace AOC2022.Utils;

public static class FileReader
{
    public static string[] Read(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
}