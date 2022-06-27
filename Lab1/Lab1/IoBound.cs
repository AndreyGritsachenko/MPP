using System.Diagnostics;
using System.Text;

namespace Lab1
{
    public class IoBound
    {
        private int threadsAmount;

        public IoBound(int threadsAmount)
        {
            this.threadsAmount = threadsAmount;
        }


        public void Execute()
        {
            string directory = "C:/MyFiles/KPI/MPP/Lab1/src/";
            List<string> fileNames = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                fileNames.Add(directory + "input" + i + ".txt");
            }
            Stopwatch stopwatch = Stopwatch.StartNew();
            SplitList(fileNames, threadsAmount).ForEach(fileList => new Thread(()=>CreateFiles(fileList)).Start());
            stopwatch.Stop();
            Console.WriteLine($"IoBound total execution time: {stopwatch.ElapsedMilliseconds}");
        }

        private void CreateFiles(List<string> fileNames)
        {
            foreach (string fileName in  fileNames)
            {
                using (FileStream fs = File.Create(fileName))
                {   
                    byte[] title = new UTF8Encoding(true).GetBytes("fileName");
                    fs.Write(title, 0, title.Length);
                }
            }
        }

        private List<List<string>> SplitList(List<string> names, int limit)
        {
            List<List<string>> splitedList = new List<List<string>>();
            int steps = names.Count / limit;
            for (int i = 0; i < steps; i++)
            {
                splitedList.Add(names.Skip(limit * i).Take(limit).ToList());

            }
            return splitedList;
        }

    }
}
