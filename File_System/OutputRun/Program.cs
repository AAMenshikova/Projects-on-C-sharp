using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.TypesOfOutput;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputRun;

public class Program
{
    public static void Main()
    {
        var fileNavigator = new FileNavigator(null);
        var fileSystem = new LocalFileSystem();
        var outputFactory = new ConsoleOutPutFactory();
        ICommandHandler commandHandler = new Connect(fileNavigator, fileSystem, outputFactory)
            .AddNext(new CopyFile(fileNavigator, fileSystem, outputFactory)
                .AddNext(new DeleteFile(fileNavigator, fileSystem, outputFactory)
                    .AddNext(new Disconnect(fileNavigator, outputFactory)
                        .AddNext(new MoveFile(fileNavigator, fileSystem, outputFactory)
                            .AddNext(new RenameFile(fileNavigator, fileSystem, outputFactory)
                                .AddNext(new ShowFile(fileNavigator, fileSystem, outputFactory)
                                    .AddNext(new TreeGoTo(fileNavigator, fileSystem, outputFactory)
                                        .AddNext(new TreeList(fileNavigator, "-", "+", " ", fileSystem, outputFactory)))))))));
        var outputRunner = new OutputRunner(commandHandler, outputFactory);
        outputRunner.Run();
    }
}