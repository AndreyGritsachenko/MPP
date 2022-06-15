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


        public void execute()
        {
            string directory = "C:/MyFiles/KPI/MPP/Lab1/src/";
            List<string> fileNames = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                fileNames.Add(directory + "input" + i + ".txt");
            }
            DateTime startTime = DateTime.UtcNow;
            splitList(fileNames, threadsAmount).ForEach(fileList => new Thread(()=>createFiles(fileList)).Start());
            DateTime endTime = DateTime.UtcNow;
            Console.WriteLine($"IoBound total execution time: {endTime - startTime}");
        }

        private void createFiles(List<string> fileNames)
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

        private List<List<string>> splitList(List<string> names, int limit)
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
