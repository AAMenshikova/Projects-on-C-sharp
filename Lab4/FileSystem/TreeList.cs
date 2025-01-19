using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class TreeList : CommandHandler
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;
    private readonly IOutPutFactory _outputFactory;
    private readonly string _fileSymbol;
    private readonly string _directorySymbol;
    private readonly string _indentSymbol;

    public TreeList(FileNavigator fileNavigator, string fileSymbol, string directorySymbol, string indentSymbol, IFileSystem fileSystem, IOutPutFactory outputFactory)
    {
        _fileNavigator = fileNavigator;
        _fileSymbol = fileSymbol;
        _directorySymbol = directorySymbol;
        _indentSymbol = indentSymbol;
        _fileSystem = fileSystem;
        _outputFactory = outputFactory;
    }

    protected override bool CanHandle(SetContext input)
    {
        return input.CommandName == "tree list";
    }

    protected override void Execute(SetContext input)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (input.ResultOfParse == new ResultType.Fail())
        {
            return;
        }

        int depth = 1;
        if (!int.TryParse(input.CommandArgs[0], out int currentDepth))
        {
            console.Output("Invalid value of depth");
            return;
        }

        if (input.CommandArgs.Count > 0)
        {
            if (currentDepth > depth)
            {
                depth = currentDepth;
            }
        }

        string? path = _fileNavigator.CurrentPath;
        string flag = input.CommandFlag;

        if (path != null && !_fileSystem.DirectoryExists(path))
        {
            console.Output("No such directory");
            return;
        }

        if (flag != "-d")
        {
            console.Output("Invalid flag");
            return;
        }

        PrintDirectoryTree(path, depth, 0);
    }

    private void PrintDirectoryTree(string? path, int depth, int currentDepth)
    {
        IOutPut console = _outputFactory.CreateOutPut();
        if (currentDepth >= depth)
        {
            return;
        }

        if (path != null)
        {
            foreach (string? directory in _fileSystem.GetDirectories(path))
            {
                console.Output(
                    $"{new string(_indentSymbol[0], currentDepth)}{_directorySymbol} {_fileSystem.GetFileName(directory)}");
                PrintDirectoryTree(directory, depth, currentDepth + 1);
            }

            foreach (string file in _fileSystem.GetFiles(path))
            {
                console.Output($"{new string(_indentSymbol[0], currentDepth)}{_fileSymbol} {_fileSystem.GetFileName(file)}");
            }
        }
    }
}