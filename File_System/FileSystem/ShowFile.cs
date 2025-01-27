using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class ShowFile : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;
    private readonly IOutPutFactory _outputFactory;

    public ShowFile(FileNavigator fileNavigator, IFileSystem fileSystem, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _fileSystem = fileSystem;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "file show";
    }

    protected override void Execute(SetContext input)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (input.ResultOfParse == new ResultType.Fail())
        {
            return;
        }

        var path = new GetPath(_fileNavigator, input.CommandArgs[0], _fileSystem);
        string flag = input.CommandFlag;
        string mode = input.CommandArgs[1];
        string absolutePath = path.GetFilePath();
        if (!_fileSystem.FileExists(absolutePath))
        {
            console.Output("File not found: " + path.Path);
            return;
        }

        if (flag != "-m")
        {
            console.Output("Invalid flag");
            return;
        }

        if (mode != "console")
        {
            console.Output("Invalid mode");
            return;
        }

        console.Output(_fileSystem.ReadFile(absolutePath));
    }
}