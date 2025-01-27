namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;

public interface IFileSystem
{
    bool FileExists(string path);

    bool DirectoryExists(string path);

    void DeleteFile(string path);

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    string ReadFile(string path);

    string CombinePath(string path1, string path2);

    string GetFileName(string path);

    string? GetDirectoryName(string path);

    bool IsPathRooted(string path);

    IEnumerable<string> GetDirectories(string path);

    IEnumerable<string> GetFiles(string path);
}