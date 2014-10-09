using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable.Runner
{
    internal sealed class Program
    {

        private static void PrintAll(IEnumerable<string, int> e)
        {
            int index = e.Start;
            string value;
            while (e.TryGetNext(ref index, out value))
            {
                Console.WriteLine(value);
            }
        }



        internal static void Main(string[] args)
        {
            var arrayList = new ArrayList<string>();
            arrayList.Add("cat");
            arrayList.Add("dog");
            arrayList.Add("fish");
            PrintAll(arrayList);
            PrintAll(arrayList);
        }
    }
}
