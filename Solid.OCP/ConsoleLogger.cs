using System;

namespace Solid.OCP
{
    internal class ConsoleLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}