using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeMessenger : IAddressee
{
    private IMessenger CurrentMessenger { get; }

    public AddresseeMessenger(IMessenger messenger)
    {
        CurrentMessenger = messenger;
    }

    public TypesOfResult GetMessage(IMessage message)
    {
        CurrentMessenger.Print(message);
        return new TypesOfResult.Success();
    }
}