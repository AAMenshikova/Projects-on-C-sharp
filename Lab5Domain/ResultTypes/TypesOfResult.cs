namespace Lab5Domain.ResultTypes;

public abstract record TypesOfResult
{
    private TypesOfResult() { }

    public sealed record Success : TypesOfResult;

    public sealed record Fail(string Message) : TypesOfResult;
}