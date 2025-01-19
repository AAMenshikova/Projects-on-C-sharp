using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public Topic(string name, Collection<IAddressee> addressees)
    {
        Name = name;
        _addresseeManager = addressees;
    }

    public string Name { get; }

    private readonly Collection<IAddressee> _addresseeManager;

    public void SendMessage(IMessage message)
    {
        foreach (IAddressee addressee in _addresseeManager)
        {
            addressee.GetMessage(message);
        }
    }
}