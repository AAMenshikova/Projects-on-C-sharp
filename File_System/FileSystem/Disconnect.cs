using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class Disconnect : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IOutPutFactory _outputFactory;

    public Disconnect(FileNavigator fileNavigator, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "disconnect";
    }

    protected override void Execute(SetContext input)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (input.ResultOfParse == new ResultType.Fail())
        {
            return;
        }

        _fileNavigator.CurrentPath = string.Empty;
        console.Output("Disconnect from file system");
    }
}