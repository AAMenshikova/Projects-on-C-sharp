using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeGroup : IAddressee
{
    public AddresseeGroup(Collection<IAddressee> addressees)
    {
        Addressees = addressees;
    }

    public Collection<IAddressee> Addressees { get; }

    public TypesOfResult GetMessage(IMessage message)
    {
        foreach (IAddressee addressee in Addressees)
        {
            addressee.GetMessage(message);
        }

        return new TypesOfResult.Success();
    }
}