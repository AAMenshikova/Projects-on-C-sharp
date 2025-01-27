using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    ConsoleColor CurrentColor { get; }

    void Print(IMessage message, ConsoleColor color);
}