using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLearning.Implementations
{
    internal class FileArgs: EventArgs
    {
        public string fileName { get; set; }
        public FileArgs(string fileName)
        {
            this.fileName = fileName;
        }
        public bool CancelSearch { get; set; }
    }
}
