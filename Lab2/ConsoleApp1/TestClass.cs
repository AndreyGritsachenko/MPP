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
        //private readonly int anountOfNumbers;

        public TestClass(int numberOfThreds, int anountOfNumbers)
        {
            this.numberOfThreds = numberOfThreds;
            //this.anountOfNumbers = anountOfNumbers;
            list = Enumerable.Range(0, anountOfNumbers).ToList();
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
