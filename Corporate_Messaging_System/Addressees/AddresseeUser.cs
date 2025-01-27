using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeUser : IAddressee
{
    private readonly User _user;

    public AddresseeUser(User user)
    {
        _user = user;
    }

    public TypesOfResult GetMessage(IMessage message)
    {
        _user.GetMessage(message);
        return new TypesOfResult.Success();
    }
}