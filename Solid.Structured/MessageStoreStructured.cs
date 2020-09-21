using System;
using System.IO;

namespace Solid.Structured
{
    public class MessageStoreStructured
    {
        public MessageStoreStructured(DirectoryInfo directory)
        {
            if (directory == null)
                throw new ArgumentException("Directory not informed");

            if (!directory.Exists)
                throw new ArgumentException("Directory does not exists");

            this.WorkingDirectory = directory;
        }
        
        public void Save(int id, string message)
        {
            Console.WriteLine($"Saving the message {message} .... file {id}.txt",  id);

            var file = this.GetFileInfo(id);
            File.WriteAllText(file.FullName, message);

            Console.WriteLine($"File saved. Message {message}");
        }

        public string Read(int id)
        {
            Console.WriteLine($"Reading message.... {id}");

            var file = this.GetFileInfo(id);

            if(!file.Exists)
            {
                Console.WriteLine($"File {id} not found");
                return "";
            }

            var msg = File.ReadAllText(file.FullName);

            Console.WriteLine("File readed");

            return msg;
        }

        public FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(this.WorkingDirectory.FullName, id + ".txt"));
        }

        public DirectoryInfo WorkingDirectory { get; }
    }
}
