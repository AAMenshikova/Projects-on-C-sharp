namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IMessage
{
    public Message(string title, string body, Enum levelOfImportance)
    {
        Title = title;
        Body = body;
        LevelOfImportance = levelOfImportance;
    }

    public string Title { get; }

    public string Body { get; }

    public Enum LevelOfImportance { get; }
}