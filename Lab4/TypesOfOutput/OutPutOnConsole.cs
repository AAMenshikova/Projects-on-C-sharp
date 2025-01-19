namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;

public class OutPutOnConsole : IOutPut
{
    public void Output(string output)
    {
        Console.WriteLine(output);
    }
}