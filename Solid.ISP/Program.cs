using Microsoft.EntityFrameworkCore;
using Solid.ISP.Stores;
using System;
using System.IO;

namespace Solid.ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = 1;

            Console.WriteLine("Store testing\n\n");

            //var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var connectionString = @"Server=localhost;Database=lucilvio.Solid;Trusted_Connection=True;MultipleActiveResultSets=true;";

            var options = new DbContextOptionsBuilder<EFContext>();
            options.UseSqlServer(connectionString);

            IStoreReader storeReader = new DataBaseStoreReader(connectionString);
            IStoreWriter storeWriter = new DataBaseStoreWriter(new EFContext(options.Options));

            //IStoreReader fileStoreReader = new FileStore(workingDirectory);
            //IStoreWriter fileStoreWriter = new FileStore(workingDirectory);

            var logger = new ConsoleLogger();

            var messageStore = new MessageStoreISP(storeReader, storeWriter, logger);
            messageStore.Save(id, "THIS IS A TEST MESSAGE");

            Console.WriteLine("\n\nReading test file");

            Console.WriteLine($"\n\nContent of the {id} file: {messageStore.Read(id)} ");
        }
    }
}
