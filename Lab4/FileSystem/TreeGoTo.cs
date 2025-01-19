using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class TreeGoTo : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;
    private readonly IOutPutFactory _outputFactory;

    public TreeGoTo(FileNavigator fileNavigator, IFileSystem fileSystem, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _fileSystem = fileSystem;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "tree goto";
    }

    protected override void Execute(SetContext input)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (input.ResultOfParse == new ResultType.Fail())
        {
            return;
        }

        var path = new GetPath(_fileNavigator, input.CommandArgs[0], _fileSystem);
        string absolutePath = path.GetFilePath();
        if (!_fileSystem.DirectoryExists(absolutePath))
        {
            console.Output("There is no such directory: " + path.Path);
            return;
        }

        _fileNavigator.CurrentPath = absolutePath;
        console.Output("Go to: " + path.Path);
    }
}