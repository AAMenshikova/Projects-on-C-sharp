namespace Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;

public class ConsoleOutPutFactory : IOutPutFactory
{
    public IOutPut CreateOutPut()
    {
        return new OutPutOnConsole();
    }
}