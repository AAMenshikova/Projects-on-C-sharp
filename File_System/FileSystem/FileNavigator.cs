namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileNavigator
{
    public FileNavigator(string? currentPath)
    {
        CurrentPath = currentPath;
    }

    public string? CurrentPath { get; set; }
}