using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class MoveFile : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;
    private readonly IOutPutFactory _outputFactory;

    public MoveFile(FileNavigator fileNavigator, IFileSystem fileSystem, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _fileSystem = fileSystem;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "file move";
    }

    protected override void Execute(SetContext input)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (input.ResultOfParse == new ResultType.Fail())
        {
            return;
        }

        var sourcePath = new GetPath(_fileNavigator, input.CommandArgs[0], _fileSystem);
        var destinationPath = new GetPath(_fileNavigator, input.CommandArgs[1], _fileSystem);
        string absoluteSourcePath = sourcePath.GetFilePath();
        string absoluteDestinationPath = destinationPath.GetFilePath();
        if (!_fileSystem.FileExists(absoluteSourcePath))
        {
            console.Output("File not found: " + sourcePath.Path);
            return;
        }

        if (_fileSystem.FileExists(_fileSystem.CombinePath(absoluteDestinationPath, _fileSystem.GetFileName(absoluteSourcePath))))
        {
            console.Output("File already exists");
            return;
        }

        _fileSystem.MoveFile(absoluteSourcePath, _fileSystem.CombinePath(absoluteDestinationPath, _fileSystem.GetFileName(absoluteSourcePath)));
        console.Output("File moved to " + destinationPath.Path);
    }
}