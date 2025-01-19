namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;

public abstract record ResultType
{
    private ResultType() { }

    public sealed record Success : ResultType;

    public sealed record Fail : ResultType;
}