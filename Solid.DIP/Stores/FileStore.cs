using System;
using System.IO;

namespace Solid.DIP
{
    internal class FileStore : IStoreReader, IStoreWriter
    {
        public FileStore(DirectoryInfo directory)
        {
            if (directory == null)
                throw new ArgumentException("Directory not informed");

            if (!directory.Exists)
                throw new ArgumentException("Directory does not exists");

            this.WorkingDirectory = directory;
        }

        public DirectoryInfo WorkingDirectory { get; }

        internal FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(this.WorkingDirectory.FullName, id + ".txt"));
        }

        public void WriteAllText(int id, string message)
        {
            var file = this.GetFileInfo(id);
            File.WriteAllText(file.FullName, message);
        }

        public string ReadAllText(int id)
        {
            var file = this.GetFileInfo(id);

            if (!file.Exists)
                return "";

            return File.ReadAllText(file.FullName);
        }
    }
}