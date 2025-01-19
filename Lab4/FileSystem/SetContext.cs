using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfResult;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class SetContext
{
    private readonly IOutPutFactory _outputFactory;

    public string CommandName { get; private set; }

    public string CommandFlag { get; private set; }

    public ResultType ResultOfParse { get; private set; }

    public Collection<string> CommandArgs { get; private set; }

    public SetContext(string input, IOutPutFactory outputFactory)
    {
        _outputFactory = outputFactory;
        CommandName = string.Empty;
        CommandFlag = string.Empty;
        CommandArgs = new Collection<string>();
        ResultOfParse = Parse(input);
    }

    private ResultType Parse(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int countOfParameters = parts.Length;
        IOutPut console = _outputFactory.CreateOutPut();
        if (countOfParameters == 0)
        {
            console.Output("No Parameters");
            return new ResultType.Fail();
        }

        if (countOfParameters == 1)
        {
            if (parts[0] != "disconnect")
            {
                console.Output("Invalid input");
                return new ResultType.Fail();
            }

            CommandName = parts[0];
            CommandFlag = string.Empty;
            CommandArgs = new Collection<string>();
        }

        if (countOfParameters == 2 || countOfParameters > 5)
        {
            console.Output("Invalid count of Parameters");
            return new ResultType.Fail();
        }

        if (countOfParameters == 3)
        {
            CommandName = parts[0] + " " + parts[1];
            if (CommandName != "tree goto" && CommandName != "file delete")
            {
                console.Output("Invalid input");
                return new ResultType.Fail();
            }

            CommandFlag = string.Empty;
            CommandArgs = [parts[2]];
        }

        if (countOfParameters == 4)
        {
            if (parts[0] == "connect")
            {
                CommandName = parts[0];
                CommandFlag = parts[2];
                CommandArgs = [parts[1], parts[3]];
            }

            if (parts[0] == "tree")
            {
                CommandName = parts[0] + " " + parts[1];
                CommandFlag = parts[2];
                CommandArgs = [parts[3]];
            }

            if (parts[0] == "file")
            {
                CommandName = parts[0] + " " + parts[1];
                CommandFlag = string.Empty;
                CommandArgs = [parts[2], parts[3]];
            }

            if (CommandName != "connect" && CommandName != "tree list" && CommandName != "file move" &&
                CommandName != "file copy" && CommandName != "file rename")
            {
                console.Output("Invalid input");
                return new ResultType.Fail();
            }
        }

        if (countOfParameters == 5)
        {
            CommandName = parts[0] + " " + parts[1];
            if (CommandName != "file show")
            {
                console.Output("Invalid input");
                return new ResultType.Fail();
            }

            CommandFlag = parts[3];
            CommandArgs = [parts[2], parts[4]];
        }

        return new ResultType.Success();
    }
}