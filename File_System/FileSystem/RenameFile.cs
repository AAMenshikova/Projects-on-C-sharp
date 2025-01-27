using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class RenameFile : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;
    private readonly IOutPutFactory _outputFactory;

    public RenameFile(FileNavigator fileNavigator, IFileSystem fileSystem, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _fileSystem = fileSystem;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "file rename";
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
        string newName = input.CommandArgs[1];
        string oldName = _fileSystem.GetFileName(absolutePath);
        string? newDirectory = _fileSystem.GetDirectoryName(absolutePath);
        if (newDirectory != null)
        {
            string newFilePath = _fileSystem.CombinePath(newDirectory, newName);

            if (!_fileSystem.FileExists(absolutePath))
            {
                console.Output("File not found: " + path.Path);
                return;
            }

            if (_fileSystem.FileExists(newFilePath))
            {
                console.Output($"File with name {newName} already exists");
                return;
            }

            _fileSystem.MoveFile(absolutePath, newFilePath);
            _fileNavigator.CurrentPath = newFilePath;
        }

        console.Output($"File {oldName} was renamed to {newName}");
    }
}