using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestClass
    {
        private readonly List<int> list = new List<int>();
        private readonly int numberOfThreds;

        public TestClass(int numberOfThreds)
        {
            list = Enumerable.Range(0,1_000_000).ToList();
            this.numberOfThreds = numberOfThreds;
        }

        public static string Transform(int element) => (element*element).ToString().GetHashCode().ToString();
        
        public string Compute() 
        { 
            ConcurrentBag<string> ts = new ConcurrentBag<string>();
            Parallel.ForEach(list, new ParallelOptions { MaxDegreeOfParallelism = numberOfThreds }, t => ts.Add(Transform(t)));
            
            var arr = ts.ToArray();
            Array.Sort(arr);
            return arr[0];
        }
    }
}
