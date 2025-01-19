using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class Connect : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;
    private readonly IOutPutFactory _outputFactory;

    public Connect(FileNavigator fileNavigator, IFileSystem fileSystem, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _fileSystem = fileSystem;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "connect";
    }

    protected override void Execute(SetContext input)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (input.ResultOfParse == new ResultType.Fail())
        {
            return;
        }

        string mode = input.CommandArgs[1];
        string flag = input.CommandFlag;
        var path = new AbsolutePath(input.CommandArgs[0], _fileSystem);
        if (!path.CheckForAbsolute())
        {
            console.Output("This is not absolute path");
            return;
        }

        if (flag != "-m")
        {
            console.Output("Invalid flag");
            return;
        }

        if (mode != "local")
        {
            console.Output("Invalid mode");
            return;
        }

        if (!_fileSystem.DirectoryExists(path.FilePath))
        {
            console.Output("There is no such directory: " + path.FilePath);
            return;
        }

        _fileNavigator.CurrentPath = path.FilePath;
        console.Output("Connect to: " + path.FilePath);
    }
}