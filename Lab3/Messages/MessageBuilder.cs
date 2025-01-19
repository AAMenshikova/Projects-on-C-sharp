namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder : IMessageBuilder
{
    private string? _title;

    private string? _body;

    private Enum? _levelOfImportance;

    public MessageBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public MessageBuilder SetBody(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder SetLevelImportance(Enum levelOfImportance)
    {
        _levelOfImportance = levelOfImportance;
        return this;
    }

    public Message? Build()
    {
        if (_title == null)
        {
            return null;
        }

        if (_body == null)
        {
            return null;
        }

        if (_levelOfImportance == null)
        {
            return null;
        }

        return new Message(_title, _body, _levelOfImportance);
    }
}