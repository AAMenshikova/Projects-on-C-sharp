using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputRun;

public class OutputRunner
{
    private readonly ICommandHandler _handler;
    private readonly IOutPutFactory _outputFactory;

    public OutputRunner(ICommandHandler handler, IOutPutFactory outputFactory)
    {
        _handler = handler;
        _outputFactory = outputFactory;
    }

    public void Run()
    {
        while (true)
        {
            Console.Write("> ");
            string? inputLine = Console.ReadLine();
            if (inputLine == null)
            {
                break;
            }

            var context = new SetContext(inputLine, _outputFactory);
            _handler.Handle(context);
        }
    }
}