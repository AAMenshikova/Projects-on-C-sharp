using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeDisplay : IAddressee
{
    private IDisplay CurrentDisplay { get; }

    public AddresseeDisplay(IDisplay display)
    {
        CurrentDisplay = display;
    }

    public TypesOfResult GetMessage(IMessage message)
    {
        CurrentDisplay.Print(message, CurrentDisplay.CurrentColor);
        return new TypesOfResult.Success();
    }
}