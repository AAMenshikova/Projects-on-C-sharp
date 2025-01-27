namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessageBuilder
{
    MessageBuilder SetTitle(string title);

    MessageBuilder SetBody(string body);

    MessageBuilder SetLevelImportance(Enum levelOfImportance);

    Message? Build();
}