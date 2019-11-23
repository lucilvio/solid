using System;
using System.IO;

namespace Solid.SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = 1;

            Console.WriteLine("Store testing\n\n");

            var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            var messageStore = new MessageStoreSRP(workingDirectory);
            messageStore.Save(id, "THIS IS A TEST MESSAGE");

            Console.WriteLine("\n\nReading test file");

            Console.WriteLine($"\n\nContent of the {id} file: {messageStore.Read(id)} ");
        }
    }
}
