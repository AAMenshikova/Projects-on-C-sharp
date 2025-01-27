using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.LoggingDecorator;

public class LoggingAddresseeDecorator : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly string _filePath;

    public LoggingAddresseeDecorator(string filePath, IAddressee addressee)
    {
        _filePath = filePath;
        _addressee = addressee;
    }

    public TypesOfResult GetMessage(IMessage message)
    {
        _addressee.GetMessage(message);
        File.AppendAllText(_filePath, message + " " + _addressee + Environment.NewLine);
        return new TypesOfResult.Success();
    }
}