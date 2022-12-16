using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr_1_charp
{
    class Data
    {
        public static List<string> ReadInfo(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<string> info = new List<string>();
            while (!reader.EndOfStream)
            {
                string temp = reader.ReadLine().Trim();
                if (!string.IsNullOrEmpty(temp))
                { 
                    info.Add(temp);
                }
            }
            reader.Close();
            return info;
        }

        public static void WriteInfo(List<Books> result, string path)
        {
            StreamWriter writer = new StreamWriter(path);
            if (result.Count == 0)
            {
                writer.WriteLine("Таких книг нет!");
            }
            else 
            {
                foreach (var element in result)
                {
                    writer.Write(element);
                }
            }
            writer.Close();
        }
    }
}
