using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable
{
    internal static class Contract
    {
        internal static void Requires(bool condition)
        {
            if (!condition)
            {
                Environment.FailFast("Bad requires");
            }
        }
    }
}
