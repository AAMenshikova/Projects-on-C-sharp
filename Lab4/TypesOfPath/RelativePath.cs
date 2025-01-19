using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;

public class RelativePath
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;

    public string FilePath { get; }

    public RelativePath(FileNavigator fileNavigator, string filePath, IFileSystem fileSystem)
    {
        _fileNavigator = fileNavigator;
        FilePath = filePath;
        _fileSystem = fileSystem;
    }

    public bool CheckForRelative()
    {
        return !_fileSystem.IsPathRooted(FilePath);
    }

    public string GetAbsolutePathFromRelativePath()
    {
        if (CheckForRelative())
        {
            if (_fileNavigator.CurrentPath != null) return _fileSystem.CombinePath(_fileNavigator.CurrentPath, FilePath);
        }

        return FilePath;
    }
}