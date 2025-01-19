using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.FilterDecorator;

public class FilterAddresseeDecorator : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly Enum _levelOfImportance;

    public FilterAddresseeDecorator(IAddressee addressee, Enum levelOfImportance)
    {
        _addressee = addressee;
        _levelOfImportance = levelOfImportance;
    }

    public TypesOfResult GetMessage(IMessage message)
    {
        if (Equals(message.LevelOfImportance, _levelOfImportance))
        {
            _addressee.GetMessage(message);
            return new TypesOfResult.Success();
        }

        return new TypesOfResult.Fail();
    }
}