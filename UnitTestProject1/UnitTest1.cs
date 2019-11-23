using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solid.DIP;
using Solid.Structured;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new MessageStoreStructured(new System.IO.DirectoryInfo("/"));
            //new MessageStoreDIP(new ReaderTest(), new WriterTest(), new LogTest());
        }

        
    }
}
