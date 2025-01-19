using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.DecoratorForMessage;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    public Collection<ReadStatusDecorator> ListOfMessages { get; }

    public User(string name)
    {
        Name = name;
        ListOfMessages = new Collection<ReadStatusDecorator>();
    }

    public string Name { get; private set; }

    public void GetMessage(IMessage message)
    {
        ListOfMessages.Add(new ReadStatusDecorator(message));
    }
}