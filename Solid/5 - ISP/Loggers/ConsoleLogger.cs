using System;

namespace Solid.ISP
{
    internal class ConsoleLogger : ILogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}