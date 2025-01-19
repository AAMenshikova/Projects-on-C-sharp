using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void Print(IMessage message)
    {
        Console.WriteLine($"Messenger: {message.Body}");
    }
}