using System;
using System.IO;

namespace Solid.OCP
{
    internal class FileStore : Store
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

        internal override FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(this.WorkingDirectory.FullName, id + ".txt"));
        }

        internal override void WriteAllText(int id, string message)
        {
            var file = this.GetFileInfo(id);
            File.WriteAllText(file.FullName, message);
        }

        internal override string ReadAllText(int id)
        {
            var file = this.GetFileInfo(id);

            if (!file.Exists)
                return "";

            return File.ReadAllText(file.FullName);
        }
    }
}