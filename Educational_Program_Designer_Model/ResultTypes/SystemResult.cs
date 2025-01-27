namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record SystemResult
{
    private SystemResult() { }

    public sealed record Success<T>(T? Element) : SystemResult;

    public sealed record Fail : SystemResult;
}