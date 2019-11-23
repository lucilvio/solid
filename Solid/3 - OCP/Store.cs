using System;
using System.IO;

namespace Solid.OCP
{
    public abstract class Store
    {
        internal abstract FileInfo GetFileInfo(int id);
        internal abstract void WriteAllText(int id, string message);
        internal abstract string ReadAllText(int id);
    }
}