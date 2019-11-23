using System;

namespace Solid.DIP
{
    internal class ConsoleLogger : ILogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}