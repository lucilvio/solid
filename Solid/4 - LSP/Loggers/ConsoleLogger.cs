using System;

namespace Solid.LSP
{
    internal class ConsoleLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}