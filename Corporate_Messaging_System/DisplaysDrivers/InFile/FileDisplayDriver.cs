namespace Itmo.ObjectOrientedProgramming.Lab3.DisplaysDrivers.InFile;

public class FileDisplayDriver
{
    private readonly string _filePath;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public void ClearOutput()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void SetColor(ConsoleColor color)
    {
        File.AppendAllText(_filePath, $"[Color: {color}]\n");
    }

    public void WriteText(string text)
    {
        File.AppendAllText(_filePath, text + Environment.NewLine);
    }
}