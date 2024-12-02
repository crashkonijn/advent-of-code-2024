namespace AdventOfCode2024.Common;

public class FileReader
{
    public string Read(string relativePath)
    {
        var basePath = AppContext.BaseDirectory;
        var filePath = Path.Combine(basePath, relativePath);

        return File.ReadAllText(filePath);
    }
}
