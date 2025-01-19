using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.DecoratorForMessage;

public class ReadStatusDecorator : IMessage
{
    private readonly IMessage _message;

    public string Title => _message.Title;

    public string Body => _message.Body;

    public Enum LevelOfImportance => _message.LevelOfImportance;

    public bool IsRead { get; private set; }

    public ReadStatusDecorator(IMessage message)
    {
        _message = message;

        IsRead = false;
    }

    public TypesOfResult MarkAsRead()
    {
        if (IsRead) return new TypesOfResult.Fail();
        IsRead = true;
        return new TypesOfResult.Success();
    }
}