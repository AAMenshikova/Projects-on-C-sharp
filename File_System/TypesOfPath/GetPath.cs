using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;

public class GetPath
{
    private readonly FileNavigator _fileNavigator;
    private readonly IFileSystem _fileSystem;

    public string Path { get; }

    public GetPath(FileNavigator fileNavigator, string filePath, IFileSystem fileSystem)
    {
        _fileNavigator = fileNavigator;
        Path = filePath;
        _fileSystem = fileSystem;
    }

    public string GetFilePath()
    {
        if (!new AbsolutePath(Path, _fileSystem).CheckForAbsolute())
        {
            return new RelativePath(_fileNavigator, Path, _fileSystem).GetAbsolutePathFromRelativePath();
        }

        return Path;
    }
}