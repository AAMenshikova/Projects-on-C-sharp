namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage
{
    string Title { get; }

    string Body { get; }

    Enum LevelOfImportance { get; }
}