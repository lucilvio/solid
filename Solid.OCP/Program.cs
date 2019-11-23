using System;
using System.IO;

namespace Solid.OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = 1;

            Console.WriteLine("Store testing\n\n");

            var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var connectionString = @"Server=localhost;Database=lucilvio.Solid;Trusted_Connection=True;MultipleActiveResultSets=true;";

            var store = new FileStore(workingDirectory);
            var dbStore = new DataBaseStore(connectionString);
            var logger = new ConsoleLogger();

            var messageStore = new MessageStoreOCP(dbStore, logger);
            messageStore.Save(id, "THIS IS A TEST MESSAGE");

            Console.WriteLine("\n\nReading test file");

            Console.WriteLine($"\n\nContent of the {id} file: {messageStore.Read(id)} ");
        }
    }
}
