using System;
using System.IO;

namespace Solid.ISP
{
    internal class FileLogger : ILogger
    {
        public FileLogger(DirectoryInfo directory)
        {
            this.Directory = directory;
        }

        public DirectoryInfo Directory { get;  }

        public override void Log(string message)
        {
            File.AppendAllText(Path.Combine(this.Directory.FullName, "log.txt"), message);
        }
    }
}