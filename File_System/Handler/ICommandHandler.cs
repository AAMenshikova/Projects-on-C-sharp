using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handler;

public interface ICommandHandler
{
    ICommandHandler AddNext(ICommandHandler handler);

    void Handle(SetContext input);
}