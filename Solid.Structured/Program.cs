using System;
using System.IO;

namespace Solid.Structured
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = 1;

            Console.WriteLine("Store testing\n\n");

            var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            var messageStore = new MessageStoreStructured(workingDirectory);
            messageStore.Save(id, "THIS IS A TEST MESSAGE");

            Console.WriteLine("\n\nReading test file");

            Console.WriteLine($"\n\nContent of the {id} file: {messageStore.Read(id)} ");
        }
    }
}
