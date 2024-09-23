﻿using DelegatesLearning.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {

        NumericOperations.Run();

        var fileLister = new FileSearcher();
        int filesFound = 0;


        List<string> filenames = new List<string>();
        EventHandler<FileArgs> onFileFound = (sender, eventArgs) =>
        {
            filenames.Add(eventArgs.fileName);
            eventArgs.CancelSearch = false;

            if (eventArgs.fileName.Contains("lib")) eventArgs.CancelSearch = true;

            filesFound++;

        };

        fileLister.FileFound += onFileFound;

        fileLister.Search(@"F:\");

        fileLister.FileFound -= onFileFound;

        Console.WriteLine(String.Join(System.Environment.NewLine, filenames));
        Console.WriteLine("Max length: " + filenames.Max(filenames => filenames.Length));
        Console.WriteLine("filesFound: " + filesFound);

        Console.WriteLine("---------");


    }
}