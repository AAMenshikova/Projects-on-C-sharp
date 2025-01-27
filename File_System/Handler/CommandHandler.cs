using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handler;

public abstract class CommandHandler : ICommandHandler
{
    private ICommandHandler? _next;

    public ICommandHandler AddNext(ICommandHandler handler)
    {
        if (_next is null)
        {
            _next = handler;
        }
        else
        {
            _next.AddNext(handler);
        }

        return this;
    }

    public void Handle(SetContext input)
    {
        if (CanHandle(input))
        {
            Execute(input);
        }
        else
        {
            _next?.Handle(input);
        }
    }

    protected abstract bool CanHandle(SetContext input);

    protected abstract void Execute(SetContext input);
}