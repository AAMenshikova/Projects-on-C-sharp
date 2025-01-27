using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public ConsoleColor CurrentColor { get; }

    public Display(ConsoleColor color)
    {
        CurrentColor = color;
    }

    public void Print(IMessage message, ConsoleColor color)
    {
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"Messenger: {message.Body}");
        Console.ResetColor();
    }
}