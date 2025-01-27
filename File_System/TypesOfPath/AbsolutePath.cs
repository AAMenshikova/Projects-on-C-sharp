using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfPath;

public class AbsolutePath
{
    private readonly IFileSystem _fileSystem;

    public string FilePath { get; }

    public AbsolutePath(string filePath, IFileSystem fileSystem)
    {
        FilePath = filePath;
        _fileSystem = fileSystem;
    }

    public bool CheckForAbsolute()
    {
        return _fileSystem.IsPathRooted(FilePath);
    }
}