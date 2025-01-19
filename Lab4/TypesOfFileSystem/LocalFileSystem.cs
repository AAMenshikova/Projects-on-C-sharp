namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;

public class LocalFileSystem : IFileSystem
{
    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public string CombinePath(string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }

    public string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public bool IsPathRooted(string path)
    {
        return Path.IsPathRooted(path);
    }

    public IEnumerable<string> GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public IEnumerable<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }
}