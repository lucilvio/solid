using Microsoft.EntityFrameworkCore;
using Solid.ISP;
using Solid.ISP.Stores;
using Solid.OCP;
using Solid.SRP;
using Solid.Structured;
using System;
using System.IO;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = 1;

            Console.WriteLine("Store testing\n\n");

            var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            var connectionString = @"Server=localhost;Database=lucilvio.Solid;Trusted_Connection=True;MultipleActiveResultSets=true;";

            //var store = new LSP.DataBaseStore(@"Server=localhost;Database=lucilvio.Solid;Trusted_Connection=True;MultipleActiveResultSets=true;");
            var log = new LSP.FileLogger(workingDirectory);
            //var store = new OCP.FileStore(workingDirectory);

            var options = new DbContextOptionsBuilder<EFContext>();
            options.UseSqlServer(connectionString);

            var databaseWriter = new ISP.DataBaseStoreWriter(new EFContext(options.Options));
            var databaseReader = new ISP.DataBaseStoreReader(connectionString);
            var fileStore = new ISP.FileStore(workingDirectory);

            var MessageStore = new MessageStoreISP(databaseReader, databaseWriter, new ISP.ConsoleLogger());
            MessageStore.Save(id, "THIS IS A TEST MESSAGE");

            Console.WriteLine("\n\nReading test file");

            Console.WriteLine($"\n\nContent of the {id} file: {MessageStore.Read(id)} ");
        }
    }

    //var connectionString = @"Server=localhost;Database=lucilvio.Solid;Trusted_Connection=True;MultipleActiveResultSets=true;";
    //var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

    //var databaseReader = new ISP.DataBaseStoreReader(connectionString);

    //var options = new DbContextOptionsBuilder<EFContext>();
    //options.UseSqlServer(connectionString);

    //        var databaseWriter = new ISP.DataBaseStoreWriter(new EFContext(options.Options));
    //var fileStore = new ISP.FileStore(workingDirectory);

    //var store = new MessageStoreISP(fileStore, fileStore, new ISP.ConsoleLogger());

}
