using System.Text;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSnaked = false;
            string word = "сеяое лоддн утегн чклоы арате йыюоу нттвм ыиплы";
            List<StringBuilder> list = new();
            foreach (var i in word.Split(' '))
                for (int i1 = 0; i1 < i.Length; i1++)
                {
                    if (list.Count <= i1)
                        list.Add(new StringBuilder());
                    list[i1].Append(i[i1]);
                }
            StringBuilder builder = new();
            if (isSnaked)
                for (int i = 0; i < list.Count; i++)
                    if (i % 2 == 1)
                        builder.Append(new string(list[i].ToString().Reverse().ToArray()));
                    else
                        builder.Append(list[i].ToString());
            else
                foreach (var i in list)
                {
                    builder.Append(i);
                }
            Console.WriteLine(builder.ToString());
        }
    }
}
