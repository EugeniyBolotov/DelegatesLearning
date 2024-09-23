using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLearning.Implementations
{
    internal class FileSearcher
    {
        public event EventHandler<FileArgs>? FileFound;


        public void Search(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
            {
                throw new ArgumentNullException("Folder not exists");
            }
            var fileargs = RaiseFileFound(directoryPath);
            var files = Directory.GetFiles(directoryPath);
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    FileFound?.Invoke(file, new FileArgs(file));
                }
                if (fileargs.CancelSearch) break;
            }
        }

        private FileArgs RaiseFileFound(string file)
        {
            var args = new FileArgs(file);
            FileFound?.Invoke(this, args);
            return args;
        }

    }
}
