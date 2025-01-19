namespace Itmo.ObjectOrientedProgramming.Lab3.DisplaysDrivers.OnConsole;

public class ConsoleDisplayDriver
{
    public void ClearOutput()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}