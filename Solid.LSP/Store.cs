using System;
using System.IO;

namespace Solid.LSP
{
    public abstract class Store
    {
        internal abstract void WriteAllText(int id, string message);
        internal abstract string ReadAllText(int id);
    }
}