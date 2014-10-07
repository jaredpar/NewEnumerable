using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewEnumerable.UnitTest
{
    public sealed class ArrayListTest
    {
        private void TestSimple<T>(params T[] p)
        {
            var arrayList = new ArrayList<T>();
            for (int i = 0; i < p.Length; i++)
            {
                arrayList.Add(p[i]);
            }

            var e = arrayList.Start;
            for (int i = 0; i < p.Length; i++)
            {
                T value;
                Assert.True(arrayList.TryGetNext(ref e, out value));
                Assert.Equal(p[i], value);
            }

            T unused;
            Assert.False(arrayList.TryGetNext(ref e, out unused));
        }

        [Fact]
        public void SimpleEnumeration()
        {
            TestSimple("cat", "dog");
            TestSimple(1, 2, 45, 4);
        }
    }
}
