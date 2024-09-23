using DelegatesLearning.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {

        NumericOperations.Run();

        Console.WriteLine("\n\n\n----------------------");

        var fileLister = new FileSearcher();
        int filesFound = 0;

        
        List<string> filenames = new List<string>();
        EventHandler<FileArgs> onFileFound = (sender, eventArgs) =>
        {
            filenames.Add(eventArgs.fileName);
            eventArgs.CancelSearch = false;

            if (eventArgs.fileName.Contains("Write")) eventArgs.CancelSearch = true;

            filesFound++;

        };

        fileLister.FileFound += onFileFound;

        fileLister.Search(@"F:\Steam");

        fileLister.FileFound -= onFileFound;

        Console.WriteLine(String.Join(System.Environment.NewLine, filenames));
        Console.WriteLine("filesFound: " + filesFound);

        Console.WriteLine("---------");


    }
}