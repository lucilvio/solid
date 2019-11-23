using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.LSP.Stores
{
    public class NullStore : Store
    {
        internal override string ReadAllText(int id)
        {
            return "";
        }

        internal override void WriteAllText(int id, string message)
        {
        }
    }
}
