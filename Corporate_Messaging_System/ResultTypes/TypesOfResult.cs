namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record TypesOfResult
{
    private TypesOfResult() { }

    public sealed record Success : TypesOfResult;

    public sealed record Fail : TypesOfResult;
}